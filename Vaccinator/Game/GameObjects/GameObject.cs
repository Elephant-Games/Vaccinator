using System;
using System.Windows.Forms;

namespace Vaccinator.Game.GameObjects {
    abstract class GameObject {
        private const int GENERATE_TIME = 10_000;

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
        }

        private void generate(object sender, EventArgs e) {
            //TODO: gameField.CreateObject(GameObject object) {}
            //Console.WriteLine("Last interval: " + this.genTimer.Interval);
            this.genTimer.Interval = this.getTime();
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
    }
}
