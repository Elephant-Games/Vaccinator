using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vaccinator.Exceptions.WindowExceptions;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    abstract class GameObject {

        protected static readonly Random random = new Random();
        private static readonly Size spriteSize = new Size(48, 48);

        public const byte PIXELS_PER_TICK = 3; //px
        public const byte CONFIDENCE_INTERVAL = 50; //px
        private const int GENERATE_TIME = 10_000; //default generate time
        private static Dictionary<Type, int> countObjects = new Dictionary<Type, int>(); //<class name, count objects>

        private FormMain gameField;
        private PictureBox sprite;

        //============================Containers=====================================

        public Point SpriteLocation {
            get {
                return this.sprite.Location;
            }

            set {
                if (
                    value.X > this.gameField.Width + CONFIDENCE_INTERVAL ||
                    value.Y > this.gameField.Height + CONFIDENCE_INTERVAL ||
                    value.X < -CONFIDENCE_INTERVAL ||
                    value.Y < -CONFIDENCE_INTERVAL
                    ) {
                    throw new PointOutOfRangeException("The point outside the confidence interval.", value);
                }
                this.gameField.Invoke(
                    new MethodInvoker(() => this.sprite.Location = value)
                );
            }
        }

        //============================Constructors====================================
        protected GameObject(FormMain gameField, Image skin) {
            this.gameField = gameField;

            //PictureBox initialization
            {
                this.sprite = new PictureBox();
                this.sprite.Image = skin;
                ((System.ComponentModel.ISupportInitialize)(this.sprite)).BeginInit();
                //this.pictureBox1.Name = "pictureBox1";
                this.sprite.Size = spriteSize;
                this.sprite.TabIndex = 0;
                this.sprite.TabStop = false;

                this.gameField.Controls.Add(this.sprite);
                this.sprite.SizeMode = PictureBoxSizeMode.Zoom;
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
        /// Уничтожает текущий игровой объект.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Destroy(object sender, EventArgs e) {
            this.sprite.Visible = false;
        }
    }

}
