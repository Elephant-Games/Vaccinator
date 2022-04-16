using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Vaccinator.Exceptions.GameObjectExceptions;
using Vaccinator.Exceptions.WindowExceptions;
using Vaccinator.GUI;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class GameObject {

        protected static readonly Random random = new Random();

        public const byte PIXELS_PER_TICK = 3; //px
        public const byte CONFIDENCE_INTERVAL = 50; //px

        private static Dictionary<Type, int> countObjects = new Dictionary<Type, int>(); //<class name, count objects>

        protected FormGame gameField;
        private readonly Panel sprite;

        //============================Containers=====================================

        public Panel Sprite {
            get {
                return this.sprite;
            }
        }

        public Size SpriteSize {
            get {
                return this.sprite.Size;
            }
        }

        public Point SpriteLocation {
            get {
                return this.sprite.Location;
            }

            set {
                if (!isHorisontalValid(value.X, this.GetType())
                    || !isVerticalValid(value.Y, this.GetType())) {
                    if (this is Player || this is Bullet) {//TODO: tp character to other side of the field
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
        public GameObject(FormGame gameField, Point spawn, Image skin) {
            this.gameField = gameField;


            //Panel initialization
            {
                this.sprite = new Panel();
                this.sprite.BackgroundImage = skin;
                //((System.ComponentModel.ISupportInitialize)(this.sprite)).BeginInit();
                //this.pictureBox1.Name = "pictureBox1";

                this.sprite.Size = Sizes.GetSize(this);

                this.sprite.TabIndex = 0;
                this.sprite.TabStop = false;
                this.sprite.BackgroundImageLayout = ImageLayout.Zoom;
                this.sprite.BackColor = Color.Transparent;
            }

            this.gameField.Invoke(new MethodInvoker(() => {
                this.sprite.Parent = this.gameField;
                this.gameField.Controls.Add(this.sprite);
                this.sprite.Location = spawn;
            }));

            if (!countObjects.ContainsKey(this.GetType()))
                countObjects.Add(this.GetType(), 1);
            else
                countObjects[this.GetType()] += 1;
        }

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
        public virtual void Destroy(object sender = null, EventArgs e = null) {
            Game.GetInstance().DeleteGameObject(this);
        }

        /// <summary>
        /// Проверка на пересечение двух объектов
        /// </summary>
        /// <param name="other">Второй объект</param>
        /// <returns>true, если пересекаются</returns>
        public bool IsIntersected(GameObject other) {
            return this.sprite.Bounds.IntersectsWith(other.sprite.Bounds);
        }

        public void SetXYCoords(Point coords) {
            this.SetXYCoords(coords.X, coords.Y);
        }

        public void SetXYCoords(int x, int y) {
            if (this.isHorisontalValid(x) && this.isVerticalValid(y)) {
                this.gameField.Invoke(new MethodInvoker(() => {
                    this.sprite.Left = x;
                    this.sprite.Top = y;
                }));
            }
        }

        /// <summary>
        /// Устанавливает координату x объекта GameObject
        /// </summary>
        /// <param name="x">Расстояние до точки от левого края окна</param>
        public void SetXCoord(int x) {
            this.SetXYCoords(x, 0);
        }


        /// <summary>
        /// Устанавливает координату y объекта GameObject
        /// </summary>
        /// <param name="y">Расстояние до точки от верхнего края окна</param>
        public void SetYCoord(int y) {
            this.SetXYCoords(0, y);
        }

        public void MoveByXY(int shiftX, int shiftY) {
            this.SetXYCoords(this.SpriteLocation.X + shiftX, this.SpriteLocation.Y + shiftY);
        }

        /// <summary>
        /// Сдвигает объект влево на lShift пикселей
        /// </summary>
        /// <param name="shift">Расстояние в пикселях, на которое нужно сдвинуть объект</param>
        public void MoveByX(int shift) {
            this.SetXCoord(this.sprite.Location.X + shift);
        }

        /// <summary>
        /// Сдвигает объект вниз на tShift пикселей
        /// </summary>
        /// <param name="shift">Расстояние в пикселях, на которое нужно сдвинуть объект</param>
        public void MoveByY(int shift) {
            this.SetYCoord(this.sprite.Location.Y + shift);
        }

        public Point GetCenter() {
            return new Point(
                this.sprite.Location.X + this.sprite.Width / 2,
                this.sprite.Location.Y + this.sprite.Height / 2
            );
        }

        public bool IsVisible() {
            return this.sprite.Visible;
        }

        //===============================================PROTECTED========================================

        protected void Show() {
            this.gameField.Invoke(new MethodInvoker(() => this.sprite.Visible = true));
        }

        protected void Hide() {
            this.gameField.Invoke(new MethodInvoker(() => this.sprite.Visible = false));
        }
        //=====================================PRIVATE====================================

        private bool isHorisontalValid(int x, Type type = null) {
            if (type == null || !type.IsSubclassOf(typeof(Bullet)) && !type.IsEquivalentTo(typeof(Player))) {
                return
                    x >= -CONFIDENCE_INTERVAL
                    && x <= this.gameField.Width + CONFIDENCE_INTERVAL;
            }
            return
                x >= 0
                && x <= this.gameField.Width;
        }

        private bool isVerticalValid(int y, Type type = null) {
            if (type == null || /*!type.IsSubclassOf(typeof(Bullet)) && */!typeof(Player).IsEquivalentTo(type)) {
                return
                    y >= -CONFIDENCE_INTERVAL
                    && y <= this.gameField.Height + CONFIDENCE_INTERVAL;
            }
            return
                y >= this.gameField.TopBarHeight
                && y <= this.gameField.Height;
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
