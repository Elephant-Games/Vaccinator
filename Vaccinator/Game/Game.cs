using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Vaccinator.Exceptions.GameObjectExceptions;
using Vaccinator.Game.GameObjects;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game {
    class Game {

        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);


        public const byte TICK = 25; //ms

        private static Game instance;

        private FormGame gameField;
        private bool isGameOn;

        private Player player;
        private LinkedList<Stone> stones;
        private LinkedList<Enemy> enemies;
        private LinkedList<Generator> generators;
        //private Dictionary< Type, LinkedList<GameObject> > gObjects = new Dictionary< Type, LinkedList<GameObject> >();

        public Player Player {
            get {
                return this.player;
            }
        }

        public LinkedList<GameObject> Stones {
            get {
                return new LinkedList<GameObject>(this.stones);
            }
        }

        public int CountStones {
            get {
                return this.stones.Count;
            }
        }

        //======================================CONSTRUCTOR================================

        private Game(FormGame gameField) {
            this.gameField = gameField;
            this.stones = new LinkedList<Stone>();
            this.enemies = new LinkedList<Enemy>();
            this.generators = new LinkedList<Generator>();

            var beginTime = new DateTime();
            while (!this.gameField.IsInit) {
                if ((beginTime - new DateTime()).TotalSeconds > 5)
                    throw new Exception("Форма не загружается!"); //todo: change to normal exception
                Thread.Sleep(50);
            }

            this.gameField.Invoke(new MethodInvoker(() => {
                this.player = new Player(this.gameField);
            }));

            //Generator init
            Generator.OnGenerated += AddGameObject;
            var gen = new Generator(this.gameField);
            gen.StartGeneration<BaseEnemy>();
            this.generators.AddLast(gen);

            //Generator stone
            gen = new Generator(this.gameField, 2);
            gen.StartGeneration<Stone>();
            this.generators.AddLast(gen);
        }

        //====================================PUBLIC=====================================

        public static Game GetInstance(object gameField = null) {
            if (instance == null) {
                if (gameField == null && instance.gameField == null)
                    throw new ArgumentNullException("GameField must have a non-zero value!");
                instance = new Game(gameField as FormGame);
            }
            return instance;
        }

        public void AddGameObject(GameObject gameObject) {
            if (gameObject is Stone)
                this.AddGameObject(gameObject as Stone);
            else if (gameObject is Enemy)
                this.AddGameObject(gameObject as Enemy);
            else
                throw new UndefinedGameObjectException($"GameObject {gameObject} of type {gameObject.GetType()} is not defined in the AddGameObject method");
        }

        private void AddGameObject(Stone stone) {
            this.stones.AddLast(stone);
        }

        private void AddGameObject(Enemy enemy) {
            this.enemies.AddLast(enemy);
        }

        public bool DeleteGameObject(GameObject gameObject) {
            ActivityController.GetInstance().MRE_Pause.WaitOne();
            if (gameObject is Stone)
                return this.DeleteGameObject(gameObject as Stone);
            else if (gameObject is Enemy)
                return this.DeleteGameObject(gameObject as Enemy);
            return false;
        }

        private bool DeleteGameObject(Stone stone) {
            this.gameField.Invoke(new MethodInvoker( () => this.gameField.Controls.Remove(stone.Sprite)));
            return this.stones.Remove(stone);
        }

        private bool DeleteGameObject(Enemy enemy) {
            this.gameField.Invoke(new MethodInvoker(() => this.gameField.Controls.Remove(enemy.Sprite)));
            return this.enemies.Remove(enemy);
        }

        public Enemy FindIntersectedEnemy(GameObject host) {
            foreach (var enemy in this.enemies) {
                if (host.IsIntersected(enemy))
                    return enemy;
            }
            return null;
        }
    }
}
