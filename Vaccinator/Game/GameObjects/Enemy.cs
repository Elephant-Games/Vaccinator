using System;
using System.Drawing;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class Enemy : Character {

        protected Enemy(FormGame gameField, Image skin, byte speed, byte shotSpeed, byte bulSpeed, byte[] bulPower, byte health) :
            base(gameField, skin, speed, shotSpeed, bulSpeed, getBulletPower(bulPower), health) {
        }

        public override void Move(object sender, EventArgs args) {
            base.MoveTo(Game.GetInstance().Player.SpriteLocation);
        }

        public override void Shot(Bullet bullet) {
        }

        public override void Move() {
            if (this.IsIntersected(Game.GetInstance().Player)) {
                base.isMoving = false;
                return;
            }
            base.Move();
        }

        private static byte getBulletPower(byte[] bulPow) {
            return (byte)GameObject.random.Next(bulPow[0], bulPow[1]);
        }
    }
}
