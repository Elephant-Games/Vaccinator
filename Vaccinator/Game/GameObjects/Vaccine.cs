using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    class Vaccine : Bullet {

        public static readonly Image SKIN = Properties.Resources.base_enemy_a;

        public Vaccine(FormGame gameField, Point spawn, Point destination, byte power, byte speed) : base(gameField, SKIN, power, speed) {
            this.SetPosition(spawn);
            this.getRealDestination(ref destination);
            this.MoveTo(destination);
        }

        protected override void findHited() {
            var game = Game.GetInstance();
            if (this.IsIntersected(game.Player)) {
                game.Player.Hit(this);
                this.Destroy();
            }

        }

        private void getRealDestination(ref Point destination) { //todo: hit player
            destination.X *= this.gameField.Width * (destination.X - this.SpriteLocation.X);
            destination.Y *= this.gameField.Width * (destination.Y - this.SpriteLocation.Y);
        }
    }
}
