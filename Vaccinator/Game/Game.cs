using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Vaccinator.Exceptions.GameObjectExceptions;
using Vaccinator.Exceptions.WindowExceptions;
using Vaccinator.Game.GameObjects;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game {
    class Game { 

        public const byte TICK = 25; //ms

        
        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);


        private static Game instance;

        private FormGame gameField;
        private bool isGameOn;

        private Player player;
        private LinkedList<Stone> stones;
        private LinkedList<Enemy> enemies;
        private LinkedList<Generator> generators;
        //private Dictionary< Type, LinkedList<GameObject> > gObjects = new Dictionary< Type, LinkedList<GameObject> >();

        //======================================GETTERS/SETTERS==================================

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
                if ((beginTime - new DateTime()).TotalMilliseconds > ActivityController.MAX_WAIT_FORM_TIME)
                    throw new IncompleteInitException("Form waiting time exceeded!");
                Thread.Sleep(ActivityController.INTERVAL_FOR_CHECKING_FORM);
            }
                
            this.player = new Player(this.gameField, this.getCenterField());

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
                if (gameField == null)
                    throw new ArgumentNullException("GameField must have a non-zero value!");
                instance = new Game(gameField as FormGame);
            }
            return instance;
        }

        public void AddGameObject(GameObject gameObject) {
            if (gameObject is Stone)
                this.addGameObject(gameObject as Stone);
            else if (gameObject is Enemy)
                this.addGameObject(gameObject as Enemy);
            else
                throw new UndefinedGameObjectException($"GameObject {gameObject} of type {gameObject.GetType()} is not defined in the AddGameObject method");
        }

        public void DeleteGameObject(GameObject gameObject) {
            ActivityController.GetInstance().MRE_Pause.WaitOne();

            if (gameObject is Stone && !(gameObject is ThrownStone))
                this.deleteGameObject(gameObject as Stone);
            else if (gameObject is Enemy)
                this.deleteGameObject(gameObject as Enemy);

            this.gameField.Invoke(new MethodInvoker(() => {
                gameObject.Sprite.Parent = null;
                gameObject.Sprite.Dispose();
                this.gameField.Controls.Remove(gameObject.Sprite);
            }));
        }

        public Enemy FindIntersectedEnemy(GameObject host) {
            foreach (var enemy in this.enemies) {
                if (host.IsIntersected(enemy))
                    return enemy;
            }
            return null;
        }

        //====================================================PRIVATE================================================

        private void addGameObject(Stone stone) {
            this.stones.AddLast(stone);
        }

        private void addGameObject(Enemy enemy) {
            this.enemies.AddLast(enemy);
        }

        private void deleteGameObject(Stone stone) {
            this.stones.Remove(stone);
        }

        private void deleteGameObject(Enemy enemy) {
            this.enemies.Remove(enemy);
        }

        private Point getCenterField() {
            return new Point(
                this.gameField.Width / 2,
                this.gameField.Height / 2
            );
        }
    }
}
