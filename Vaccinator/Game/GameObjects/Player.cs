using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    class Player : Character, IMoveable {
        public const byte SPEED = 2;
        public const byte SHOT_SPEED = 3;
        public const byte BULLET_SPEED = 3;
        public const byte BULLET_POWER = 2;
        public const byte HEALTH = 5;
        public static readonly Image SKIN = Properties.Resources.player_character_a;

        private byte countStones;

        public Player(FormGame gameField) :
            base(gameField, SKIN, SPEED, SHOT_SPEED, BULLET_SPEED, BULLET_POWER, HEALTH) {

            base.SpriteLocation = new Point(gameField.Width / 2, gameField.Height / 2);
            this.countStones = 0;
        }

        public override void Move() {
            //todo: start work
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
            if (x == 0 && y == 0)
                return;

            base.MoveToLeft(x);
            base.MoveToTop(y);
        }

        public async void FindObjectForPicking() {
            await Task.Run(() => {
                if (countStones >= 10)
                    return;

                foreach (var stone in Game.GetInstance().Stones) {
                    if (this.IsIntersected(stone) && stone.IsVisible()) {
                        ((Stone)stone).Pick(this);
                        ++this.countStones;
                    }
                }

                base.gameField.SetAmmoText(this.countStones);
            });
        }
    }
}
