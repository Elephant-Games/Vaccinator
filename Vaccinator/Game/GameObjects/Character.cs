using System;
using System.Drawing;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class Character : MovingObject {
        private const byte SAFE_JUMP_INTERVAL = 5; //px

        private byte shotSpeed;
        private byte bulSpeed;
        private byte bulPower;
        private byte health;
        
        //==========================================ABSTRACT=============================================
        public abstract void Shot(Bullet bullet);

        //=========================================CONSTRUCTOR===========================================
        protected Character(FormGame gameField, Image sprite, byte speed, byte shotSpeed, byte bulSpeed, byte bulPower, byte health) :
            base(gameField, sprite, speed) {
            
            this.shotSpeed = shotSpeed;
            this.bulSpeed = bulSpeed;
            this.bulPower = bulPower;
            this.health = health;
        }

        public void Hit(Bullet bullet) {
            if (this.health < bullet.Power) {
                if (this is Player) { } //todo: gameover
                this.Destroy();
            }
            this.health -= bullet.Power;
            bullet.Destroy();
        }

        protected bool isSpriteCanJumpToPoint(Point point) {
            return
                !point.Equals(base.SpriteLocation)
                && Math.Abs(point.X - base.SpriteLocation.X) < SAFE_JUMP_INTERVAL
                && Math.Abs(point.Y - base.SpriteLocation.Y) < SAFE_JUMP_INTERVAL;
        }
    }
}
