using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    class ThrownStone : Stone {

        private const byte SPEED = 1;

        public ThrownStone(FormGame gameField, Point spawn, Point destination) : base(gameField, SPEED) {
            this.SetPosition(spawn);
            base.MoveTo(destination);

            this.MovementHadEnded += this.EndMove;
        }

        public override void Move(object sender, EventArgs args) {
            base.Move();
        }

        private void EndMove() {
            base.Destroy();
        }
    }
}
