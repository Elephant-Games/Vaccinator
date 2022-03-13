﻿using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Vaccinator.Game.GameObjects;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game {
    class Generator {
        private const ushort INTERVAL = 10_000;

        private FormGame gameField;
        private double freq;

        private Random random;
        private System.Timers.Timer genTimer;
        private Type genType;

        public delegate void Generate(GameObject gameObject);
        public static event Generate OnGenerated;

        public Generator(FormGame gameField, double freq = 1.0) {
            this.gameField = gameField;
            this.freq = freq;

            this.random = new Random();
            this.genTimer = new System.Timers.Timer();
            this.setInterval();
            this.genTimer.Elapsed += this.generate;
        }

        public void StartGeneration<T>() where T : GameObject {
            if (this.genType != null)
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
            this.genTimer.Stop(); //todo: temp
            this.setInterval();

            GameObject tempGObj = null;
            this.gameField.Invoke(new MethodInvoker(() => {
                tempGObj = Activator.CreateInstance(this.genType, this.gameField) as GameObject; //TODO: current gameField
                tempGObj.SpriteLocation = new Point(this.random.Next(0, 100), this.random.Next(0, 100));//this.getPoint();
            }));
            Game.GetInstance().AddGameObject(tempGObj);
            Console.WriteLine(tempGObj.GetType());
            OnGenerated(tempGObj);
            this.genTimer.Start(); //todo: temp
        }

        private Point getPoint() {
            int x = this.random.Next(-GameObject.CONFIDENCE_INTERVAL, this.gameField.Width + GameObject.CONFIDENCE_INTERVAL),
                y = this.random.Next(-GameObject.CONFIDENCE_INTERVAL, this.gameField.Height + GameObject.CONFIDENCE_INTERVAL),
                orient = this.random.Next(0, Enum.GetNames(typeof(Sides)).Length);

            switch ( (Sides)orient ) {
                case Sides.TOP:
                    y = -GameObject.CONFIDENCE_INTERVAL;
                    break;
                case Sides.BOTTOM:
                    y = this.gameField.Height + GameObject.CONFIDENCE_INTERVAL;
                    break;
                case Sides.LEFT:
                    x = -GameObject.CONFIDENCE_INTERVAL;
                    break;
                case Sides.RIGHT:
                    x = this.gameField.Width + GameObject.CONFIDENCE_INTERVAL;
                    break;
            }

            return new Point(x, y);
        }

        /// <summary>
        /// Получение времени для следующего интервала таймера (константное время генерации +- половина этого времени) * частота генерации.
        /// </summary>
        /// <returns>Время для следующего интервала таймера</returns>
        private void setInterval() {
            this.genTimer.Interval = (INTERVAL + this.random.Next(-INTERVAL / 2, INTERVAL / 2)) * freq;
        }

        //====================================INNER TYPES=====================================

        private enum Sides {
            TOP,
            BOTTOM,
            LEFT,
            RIGHT
        }
    }
}
