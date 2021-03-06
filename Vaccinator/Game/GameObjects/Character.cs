using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.GUI;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class Character : GameObject, IMoveable {
        private const byte SAFE_JUMP_INTERVAL = 5; //px
        private const byte SAFE_AREA_INTERVAL = 68; //px

        private readonly System.Timers.Timer updater = new System.Timers.Timer(Game.TICK);

        private byte speed;
        private byte shotSpeed;
        private byte bulSpeed;
        private byte bulPower;
        private byte health;

        private double shift = 0;

        private Point destination;
        private bool isMoving;

        protected Character(FormGame gameField, Image sprite, byte speed, byte shotSpeed, byte bulSpeed, byte bulPower, byte health) :
            base(gameField, sprite) {
            
            this.speed = speed;
            this.shotSpeed = shotSpeed;
            this.bulSpeed = bulSpeed;
            this.bulPower = bulPower;
            this.health = health;

            this.isMoving = true;
            this.destination = new Point(0, 0);//base.SpriteLocation;

            this.updater.Elapsed += Move;
            this.updater.Start();
        }


        /// <summary>
        /// Задаёт точку назначения и начинает перемещать объект в её сторону
        /// </summary>
        /// <param name="destination">Точка назначения</param>
        public void MoveTo(Point destination) {
            this.destination = destination;
            this.isMoving = true;
            this.Move();
        }

        public virtual void Move() {
            {
                var aController = ActivityController.GetInstance();
                if (!aController.MRE_Pause.WaitOne(0)) {
                    this.updater.Stop();
                    aController.MRE_Pause.WaitOne();
                    this.updater.Start();
                }
            }
            //if (this.DistanceTo(Game.GetInstance().Players.First.Value) <= SAFE_AREA_INTERVAL) { //todo: temp solution
            if (this.IsIntersected(Game.GetInstance().Player)) {
                this.isMoving = false;
                return;
            }

            double delX = this.destination.X - base.SpriteLocation.X;
            double delY = this.destination.Y - base.SpriteLocation.Y;
            double delXS = Math.Pow(delX, 2);
            double delYS = Math.Pow(delY, 2);
            double length = Math.Sqrt(delXS + delYS);

            double shift = this.getShift();

            int nX = (int) (shift * (delX / length)),
                nY = (int) (shift * (delY / length));


            base.MoveToLeft(nX);
            base.MoveToTop(nY);
        }

        public virtual void Move(object sender, EventArgs args) {
            if (!this.isMoving)
                return;
            this.Move();
        }

        protected bool isSpriteCanJumpToPoint(Point point) {
            return
                !point.Equals(base.SpriteLocation)
                && Math.Abs(point.X - base.SpriteLocation.X) < SAFE_JUMP_INTERVAL
                && Math.Abs(point.Y - base.SpriteLocation.Y) < SAFE_JUMP_INTERVAL;
        }

        protected double getShift() {
            if (this.shift == 0)
                this.shift = this.speed * GameObject.PIXELS_PER_TICK;
            return this.shift;
        }

        public void Stop() {
            this.destination = base.SpriteLocation;
            this.isMoving = false;
        }
    }
}
