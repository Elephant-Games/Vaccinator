using System;
using System.Drawing;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class MovingObject : GameObject {

        protected delegate void EndOfMovement();
        protected event EndOfMovement MovementHadEnded;

        protected readonly System.Timers.Timer updater = new System.Timers.Timer(Game.TICK);

        protected bool isMoving;
        private byte speed;
        private double shift;

        private Point destination;
        
        //==============================================GETTERS/SETTERS===============================================================

        protected Point Destination {
            get {
                return this.destination;
            }
        }

        //===============================================CONSTRUCTORS=================================================================

        public MovingObject(FormGame gameField, Image sprite, byte speed) : base(gameField, sprite) {
            this.speed = speed;
            this.shift = 0;
            this.isMoving = true;//base.SpriteLocation;

            this.MovementHadEnded += this.EndMove;

            this.updater.Elapsed += this.Move;
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

            if (this.destination.Equals(this.SpriteLocation))
                this.MovementHadEnded();
            //if (this.DistanceTo(Game.GetInstance().Players.First.Value) <= SAFE_AREA_INTERVAL) { //todo: temp solution

            double delX = this.destination.X - base.SpriteLocation.X;
            double delY = this.destination.Y - base.SpriteLocation.Y;
            double delXS = Math.Pow(delX, 2);
            double delYS = Math.Pow(delY, 2);
            double length = Math.Sqrt(delXS + delYS);

            double shift = this.getShift();

            int nX = (int)(shift * (delX / length)),
                nY = (int)(shift * (delY / length));


            base.MoveByX(nX);
            base.MoveByY(nY);
        }

        public virtual void Move(object sender, EventArgs args) {
            if (!this.isMoving)
                return;
            this.Move();
        }

        public void Stop() {
            this.destination = base.SpriteLocation;
            this.isMoving = false;
        }

        public void StartUpdater() {
            this.updater.Start();
        }

        public override void Destroy(object sender = null, EventArgs e = null) {
            this.updater.Dispose();
            base.Destroy(sender, e);
        }

        protected double getShift() {
            if (this.shift == 0)
                this.shift = this.speed * GameObject.PIXELS_PER_TICK;
            return this.shift;
        }

        private void EndMove() {
            this.isMoving = false;
            this.updater.Stop();
        }
    }
}
