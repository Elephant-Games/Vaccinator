using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    class ThrownStone : Stone {

        public ThrownStone(FormGame gameField, Point spawn, Point shift, byte power, byte speed) : base(gameField, power, speed) {
            this.SetPosition(spawn);
            this.shift = shift;
        }

        public override void Move() {
            this.isEndMove();

            this.gameField.Invoke(new MethodInvoker(() => {
                this.Sprite.Left += shift.X;
                this.Sprite.Top += shift.Y;
            }));

            this.findHited();
        }

        protected override void isEndMove() {
            if (this.shift.X == 0 && this.shift.Y == 0)
                this.Destroy();
            base.isEndMove();
        }
    }
}
