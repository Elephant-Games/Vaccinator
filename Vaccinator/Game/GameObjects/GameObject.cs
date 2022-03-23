using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vaccinator.Exceptions.WindowExceptions;
using Vaccinator.GUI;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class GameObject {

        protected static readonly Random random = new Random();

        public const byte PIXELS_PER_TICK = 3; //px
        public const byte CONFIDENCE_INTERVAL = 50; //px
        private const int GENERATE_TIME = 10_000; //default generate time
        private static Dictionary<Type, int> countObjects = new Dictionary<Type, int>(); //<class name, count objects>

        private FormGame gameField;
        private Panel sprite;

        //============================Containers=====================================

        public Point SpriteLocation {
            get {
                return this.sprite.Location;
            }

            set {
                if (!isHorisontalValid(value.X)
                    || !isVerticalValid(value.Y)) {
                    if (this is Player) {
                        /*this.gameField.Invoke( new MethodInvoker( () => {
                            this.sprite.Location = new Point(
                                this.sprite.Location.X - 2 * this.sprite.Location.X,
                                this.sprite.Location.Y - 2 * this.sprite.Location.Y
                            );
                        }));*/ //TODO: tp character to other side of the field
                        return;
                    }
                    throw new PointOutOfRangeException("The point outside the confidence interval.", value);
                }
                this.gameField.Invoke(
                    new MethodInvoker( () => this.sprite.Location = value )
                );
            }
        }

        //============================Constructors====================================
        protected GameObject(FormGame gameField, Image skin) {
            this.gameField = gameField;

            //PictureBox initialization
            {
                this.sprite = new Panel();
                this.sprite.BackgroundImage = skin;
                //((System.ComponentModel.ISupportInitialize)(this.sprite)).BeginInit();
                //this.pictureBox1.Name = "pictureBox1";

                this.sprite.Size = Sizes.GetSize(this);
                this.sprite.TabIndex = 0;
                this.sprite.TabStop = false;

                this.gameField.Controls.Add(this.sprite);
                this.sprite.BackgroundImageLayout = ImageLayout.Zoom;
                this.sprite.Parent = this.gameField;
                this.sprite.BackColor = Color.Transparent;
            }

            if (!countObjects.ContainsKey(this.GetType()))
                countObjects.Add(this.GetType(), 1);
            else
                countObjects[this.GetType()] += 1;
        }

        /*public void SetSprite(PictureBox sprite) {
            this.sprite = sprite;
        }*/

        /// <summary>
        /// Рассчитывает расстояние до центра объекта GameObject
        /// </summary>
        /// <param name="obj">Другой объект</param>
        /// <returns></returns>
        public int DistanceTo(GameObject obj) {
            if (obj.Equals(this)
                || this.SpriteLocation.Equals(obj.SpriteLocation) )
                return 0;

            return (int)Math.Floor(Math.Sqrt(
                Math.Pow(this.SpriteLocation.X - obj.SpriteLocation.X, 2)
                + Math.Pow(this.SpriteLocation.Y - obj.SpriteLocation.Y, 2)));
        }

        /// <summary>
        /// Уничтожает текущий игровой объект.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Destroy(object sender, EventArgs e) {
            this.sprite.Visible = false;
            Game.GetInstance().DeleteGameObject(this);
        }

        public void SetLeftCoord(int left) {
            if (isHorisontalValid(left))
                this.gameField.Invoke(new MethodInvoker(() => this.sprite.Left = left));
        }

        public void SetTopCoord(int top) {
            if (isVerticalValid(top))
                this.gameField.Invoke(new MethodInvoker(() => this.sprite.Top = top));
        }

        public void MoveToLeft(int lShift) {
            this.SetLeftCoord(this.sprite.Location.X + lShift);
        }

        public void MoveToTop(int tShift) {
            this.SetTopCoord(this.sprite.Location.Y + tShift);
        }

        //=====================================PRIVATE====================================

        private bool isHorisontalValid(int x) {
            return
                x >= -CONFIDENCE_INTERVAL
                && x <= this.gameField.Width + CONFIDENCE_INTERVAL;
        }

        private bool isVerticalValid(int y) {
            return
                y >= -CONFIDENCE_INTERVAL
                && y <= this.gameField.Height + CONFIDENCE_INTERVAL;
        }

        private class Sizes {
            public static readonly Size CHARACTER = new Size(48, 48);
            public static readonly Size BULLET = new Size(10, 10);

            public static Size GetSize(GameObject obj) {
                if (obj is Character)
                    return CHARACTER;
                else if (obj is Bullet)
                    return BULLET;
                return new Size();
            }
        }
    }

}
