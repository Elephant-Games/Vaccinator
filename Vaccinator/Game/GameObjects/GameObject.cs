using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    abstract class GameObject {

        protected static readonly Random random = new Random();

        private const int GENERATE_TIME = 10_000; //default generate time
        private static Dictionary<Type, int> countObjects = new Dictionary<Type, int>(); //<class name, count objects>

        private FormMain gameField;
        private PictureBox sprite;

        protected GameObject(FormMain gameField, Image skin) {
            this.gameField = gameField;
            
            //TODO: PictureBox initialization
            this.sprite.Image = skin;
            
            //Add 1 or count + 1
            countObjects.Add(this.GetType(), countObjects.ContainsKey(this.GetType()) ? countObjects[this.GetType()] + 1 : 1);
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
