using System;
using System.Drawing;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class Enemy : Character {

        private System.Timers.Timer shoter = new System.Timers.Timer();

        protected Enemy(FormGame gameField, Image skin, byte speed, byte shotSpeed, byte bulSpeed, byte[] bulPower, byte health) :
            base(gameField, skin, speed, shotSpeed, bulSpeed, getBulletPower(bulPower), health) {

            this.shoter.Interval = this.ShotSpeed * 1000;
            this.shoter.Elapsed += Shot;
            this.shoter.Start();
        }

        public override void Move(object sender, EventArgs args) {
            base.MoveTo(Game.GetInstance().Player.SpriteLocation);
        }

        protected void Shot(object sender, EventArgs args) {
            new Vaccine(this.gameField, this.SpriteLocation, Game.GetInstance().Player.SpriteLocation, this.BulPower, this.BulSpeed);
        }

        public override void Move() {
            if (this.IsIntersected(Game.GetInstance().Player)) {
                base.isMoving = false;
                return;
            }
            base.Move();
        }

        public override void Destroy(object sender = null, EventArgs e = null) {
            this.shoter.Dispose();
            base.Destroy(sender, e);
        }

        private static byte getBulletPower(byte[] bulPow) {
            return (byte)GameObject.random.Next(bulPow[0], bulPow[1]);
        }
    }
}
