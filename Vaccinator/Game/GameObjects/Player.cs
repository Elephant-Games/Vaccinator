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

        public Player(FormGame gameField) :
            base(gameField, SKIN, SPEED, SHOT_SPEED, BULLET_SPEED, BULLET_POWER, HEALTH) {

            base.SpriteLocation = new Point(gameField.Width / 2, gameField.Height / 2);
        }

        public override async void Move() {
            //todo: start work

            await Task.Run(() => {
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
                base.SpriteLocation = new Point(base.SpriteLocation.X + x, base.SpriteLocation.Y + y);
            });
        }
    }
}
