using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    class Player : Character {
        public const byte SPEED = 2;
        public const byte SHOT_SPEED = 3;
        public const byte BULLET_SPEED = 3;
        public const byte BULLET_POWER = 2;
        public const byte HEALTH = 5;
        public static readonly Image SKIN = Properties.Resources.player_character_a;

        private Point lastDirection;
        private byte countStones;

        public Player(FormGame gameField) :
            base(gameField, SKIN, SPEED, SHOT_SPEED, BULLET_SPEED, BULLET_POWER, HEALTH) {
           
            base.SpriteLocation = new Point(gameField.Width / 2, gameField.Height / 2);
            this.countStones = 0;
            this.lastDirection = new Point();
        }

        public override void Move() {
            //todo: start work
            ActivityController.GetInstance().MRE_Pause.WaitOne();
            this.FindObjectForPicking();

            int x = 0,
            y = 0;
            int shift = (int)base.getShift();

            if (Game.GetAsyncKeyState((int)Keys.Up))
                y -= shift;
            if (Game.GetAsyncKeyState((int)Keys.Down))
                y += shift;
            if (Game.GetAsyncKeyState((int)Keys.Left))
                x -= shift;
            if (Game.GetAsyncKeyState((int)Keys.Right))
                x += shift;

            (new Thread(() => {
                if (x != 0 || y != 0)
                    this.lastDirection = new Point(x, y);

                if (Game.GetAsyncKeyState((int)Keys.Space))
                    this.Shot(this.lastDirection); //todo: test
            })).Start();


            if (x == 0 && y == 0)
                return;

            this.MoveByX(x);
            this.MoveByY(y);
        }

        public async void FindObjectForPicking() {
            await Task.Run(() => {
                if (this.countStones >= 10)
                    return;

                foreach (var stone in Game.GetInstance().Stones) {
                    if (this.IsIntersected(stone) && stone.IsVisible()) {
                        stone.Destroy();
                        ++this.countStones;
                    }
                }

                this.gameField.SetAmmoText(this.countStones);
            });
        }

        protected override bool Shot(Bullet bullet) {
            if (!base.Shot(bullet))
                return false;
            --this.countStones;
            return true;
        }

        private void Shot(Point shift) {
            if (this.countStones == 0 || !this.canShot)
                return;

            shift.X *= this.BulSpeed;
            shift.Y *= this.BulSpeed;
            
            this.Shot(new ThrownStone(this.gameField, this.SpriteLocation, shift, this.BulPower, this.BulSpeed));
        }
    }
}
