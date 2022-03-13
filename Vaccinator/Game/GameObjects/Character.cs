using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    abstract class Character : GameObject, IMoveable {

        private byte speed;
        private byte shotSpeed;
        private byte bulSpeed;
        private byte bulPower;
        private byte health;

        private Point destination;
        private bool isMoving;

        protected Character(FormMain gameField, Image sprite, byte speed, byte shotSpeed, byte bulSpeed, byte bulPower, byte health) :
            base(gameField, sprite) {
            
            this.speed = speed;
            this.shotSpeed = shotSpeed;
            this.bulSpeed = bulSpeed;
            this.bulPower = bulPower;
            this.health = health;

            this.isMoving = false;

            //TODO: temp
            this.isMoving = true;
            this.destination = new Point(0, 0);//base.SpriteLocation;
        }

        public void MoveTo(Point destination) {
            this.destination = destination;
            this.Move();
        }

        public void Move() {
            if (!this.isMoving)
                return;
            //Console.WriteLine($"nx = {this.destination.X}, ny = {this.destination.Y}");
            if (
                !this.destination.Equals(base.SpriteLocation)
                && Math.Abs(this.destination.X - base.SpriteLocation.X) < 5
                && Math.Abs(this.destination.Y - base.SpriteLocation.Y) < 5
                ) {
                base.SpriteLocation = this.destination;
                return;
            }

            if (base.SpriteLocation.Equals(new Point(400, 400))) {
                this.isMoving = false;
                return;
            }
            
            if (base.SpriteLocation.Equals(this.destination))
                this.destination = new Point(400, 400);

            double delX = this.destination.X - base.SpriteLocation.X;
            double delY = this.destination.Y - base.SpriteLocation.Y;
            double delXS = Math.Pow(delX, 2);
            double delYS = Math.Pow(delY, 2);
            double length = Math.Sqrt(delXS + delYS);

            double shift = this.speed * GameObject.PIXELS_PER_TICK;

            double nX = (shift * (delX / length)),
                nY = (shift * (delY / length));

            base.SpriteLocation = new Point( //todo: optimize
                (int)Math.Floor(base.SpriteLocation.X + nX),
                (int)Math.Floor(base.SpriteLocation.Y + nY)
            );
        }

        public void Stop() {
            this.destination = base.SpriteLocation;
            this.isMoving = false;
        }
    }
}
