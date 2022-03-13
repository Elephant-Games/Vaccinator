using System;
using System.Collections.Generic;
using System.Timers;
using Vaccinator.Game.GameObjects;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game {
    class Game {
        private const byte TICK = 20; //ms

        private static Game instance;

        private FormGame gameField;
        private bool isGameOn;
        
        private LinkedList< Generator >[] generators = new LinkedList< Generator >[2];
        private Dictionary< Type, LinkedList<GameObject> >[] gObjects = new Dictionary< Type, LinkedList<GameObject> >[2];

        private Timer updateTimer;

        private Game(FormGame gameField) { //TODO: remake constructor
            this.gameField = gameField;

            this.generators[0] = new LinkedList< Generator >();
            this.gObjects[0] = new Dictionary< Type, LinkedList<GameObject> >();

            Generator.OnGenerated += AddGameObject;
            Generator gen = new Generator(this.gameField);
            gen.StartGeneration<BaseEnemy>();
            this.generators[0].AddLast(gen);

            this.updateTimer = new Timer(TICK);
            updateTimer.Elapsed += this.UpdateTimer_Elapsed;
            this.updateTimer.Start();
        }

        public static Game GetInstance(FormGame gameField = null) {
            if (instance == null) {
                if (gameField == null && instance.gameField == null)
                    throw new ArgumentNullException("GameField must have a non-zero value!");
                instance = new Game(gameField);
            }
            return instance;
        }

        public void AddGameObject(GameObject gameObject) {
            if (!this.gObjects[0].ContainsKey(gameObject.GetType()))
                this.gObjects[0].Add(gameObject.GetType(), new LinkedList<GameObject>());
            this.gObjects[0][gameObject.GetType()].AddLast(gameObject);
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e) {
            foreach (var item in this.gObjects[0]) {
                //Console.WriteLine($"{item.Key} is subclass of IMoveable = {}");
                if (typeof(IMoveable).IsAssignableFrom(item.Key))
                    foreach (var elem in item.Value)
                        ((IMoveable)elem).Move();
            }
        }
    }
}
