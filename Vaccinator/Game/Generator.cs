using System;
using System.Timers;
using Vaccinator.Game.GameObjects;

namespace Vaccinator.Game {
    class Generator {
        private const ushort INTERVAL = 10_000;

        private double freq;

        private Game game;
        private Random random;
        private Timer genTimer;
        private Type genType;

        public Generator(double freq = 1.0) {
            this.freq = freq;

            this.random = new Random();
            this.game = Game.GetInstance();
            this.genTimer = new Timer();
            this.setInterval();
            this.genTimer.Elapsed += this.generate;
        }

        public void StartGeneration<T>() where T : GameObject, new() {
            if (this.genType == null)
                throw new FieldAccessException("The generation has been launched!");
            this.genType = typeof(T);
            this.genTimer.Start();
        }

        /// <summary>
        /// Генератор игровых объектов. Достаточно создать один объект, задать частоту появления и объекты сами будут генерироваться.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generate(object sender, ElapsedEventArgs e) {
            this.setInterval();
            this.game.AddGameObject( Activator.CreateInstance(this.genType) as GameObject );
        }

        /// <summary>
        /// Получение времени для следующего интервала таймера (константное время генерации +- половина этого времени) * частота генерации.
        /// </summary>
        /// <returns>Время для следующего интервала таймера</returns>
        private void setInterval() {
            this.genTimer.Interval = (INTERVAL + this.random.Next(-INTERVAL / 2, INTERVAL / 2)) * freq;
        }
    }
}
