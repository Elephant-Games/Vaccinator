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

        protected bool canShot = true;

        //==========================================GETTERS/SETTERS======================================

        public byte ShotSpeed {
            get {
                return this.shotSpeed;
            }
        }

        public byte BulSpeed {
            get {
                return this.bulSpeed;
            }
        }

        public byte BulPower {
            get {
                return this.bulPower;
            }
        }

        //=========================================CONSTRUCTOR===========================================
        protected Character(FormGame gameField, Point spawn, Image skin, byte speed, byte shotSpeed, byte bulSpeed, byte bulPower, byte health) :
            base(gameField, spawn, skin, speed) {
            
            this.shotSpeed = shotSpeed;
            this.bulSpeed = bulSpeed;
            this.bulPower = bulPower;
            this.health = health;
        }

        public void Hit(Bullet bullet) {    
            /*if (!bullet.IsActive)
                return;*/
            if (!(this is Player) && (bullet is Vaccine))
                return;

            if (this.health < bullet.Power) {
                if (this is Player)
                    Program.Exit();
                this.Destroy();
            }
            else
                this.health -= bullet.Power;
        }

        protected virtual bool Shot(Bullet bullet) {
            if (!this.canShot) {
                return false;
            }
            this.canShot = false;

            var timer = new System.Timers.Timer();
            timer.Interval = this.shotSpeed * 1000;
            timer.Elapsed += (s, a) => {
                this.canShot = true;
                timer.Dispose();
            };
            timer.Start();
            return true;
        }

        protected bool isSpriteCanJumpToPoint(Point point) {
            return
                !point.Equals(base.SpriteLocation)
                && Math.Abs(point.X - base.SpriteLocation.X) < SAFE_JUMP_INTERVAL
                && Math.Abs(point.Y - base.SpriteLocation.Y) < SAFE_JUMP_INTERVAL;
        }
    }
}
