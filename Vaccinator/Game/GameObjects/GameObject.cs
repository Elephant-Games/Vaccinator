using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vaccinator.Game.GameObjects {
    abstract class GameObject {
        private const int GENERATE_TIME = 10_000; //default generate time

        private static Dictionary<string, int> countObjects = new Dictionary<string, int>(); //<class name, count objects>

        private Form gameField;
        private PictureBox sprite;
        private double freq;
        private System.Timers.Timer genTimer; //Generate timer
        private Random random; //random for generate

        public GameObject(PictureBox sprite, double freq = 1.0) {
            this.sprite = sprite;
            this.freq = freq;
            this.genTimer = new System.Timers.Timer(this.getTime());
            this.genTimer.Elapsed += generate;
            this.genTimer.Start();
            //Add 1 or count + 1
            countObjects.Add(this.GetType().Name, countObjects.ContainsKey(this.GetType().Name) ? countObjects[this.GetType().Name] + 1 : 1);
        }

        /// <summary>
        /// Получение времени для следующего интервала таймера (константное время генерации +- половина этого времени) * частота генерации
        /// </summary>
        /// <returns>Время для следующего интервала таймера</returns>
        private int getTime() {
            if (this.random == null)
                this.random = new Random();
            int halfGenTime = GENERATE_TIME / 2;
            return (int)((this.random.Next(-halfGenTime, halfGenTime) + GENERATE_TIME) * this.freq);
        }

        private void generate(object sender, EventArgs e) {
            //TODO: gameField.CreateObject(GameObject object) {}
            this.genTimer.Interval = this.getTime();
        }

        /// <summary>
        /// Уничтожает текущий игровой объект
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Destroy(object sender, EventArgs e) {
            this.genTimer.Close();
            this.sprite.Visible = false;
        }
    }
}
