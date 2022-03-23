using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Vaccinator.Game.GameObjects;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game {
    class Game {

        [DllImport("user32.dll")]
        public static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);


        private const byte TICK = 25; //ms

        private static Game instance;

        private FormGame gameField;
        private bool isGameOn;
        
        private LinkedList< Generator >[] generators = new LinkedList< Generator >[2];
        private Dictionary< Type, LinkedList<GameObject> >[] gObjects = new Dictionary< Type, LinkedList<GameObject> >[2];

        private System.Timers.Timer updateTimer;

        public LinkedList<GameObject> Players {
            get {
                return this.gObjects[0][typeof(Player)];
            }
        }

        //======================================CONSTRUCTOR================================

        private Game(FormGame gameField) { //TODO: remake constructor
            this.gameField = gameField;

            this.generators[0] = new LinkedList< Generator >();
            this.gObjects[0] = new Dictionary< Type, LinkedList<GameObject> >();

            DateTime beginTime = new DateTime();
            while (!this.gameField.IsInit) {
                if ((beginTime - new DateTime()).TotalSeconds > 5)
                    throw new Exception("Форма не загружается!"); //todo: change to normal exception
                Thread.Sleep(50);
            }

            this.gameField.Invoke(new MethodInvoker(() => {
                this.gObjects[0].Add(typeof(Player), new LinkedList<GameObject>());
                this.gObjects[0][typeof(Player)].AddLast(new Player(this.gameField));
            }));

            //Generator init
            Generator.OnGenerated += AddGameObject;
            Generator gen = new Generator(this.gameField);
            gen.StartGeneration<BaseEnemy>();
            this.generators[0].AddLast(gen);


            //Main game timer
            this.updateTimer = new System.Timers.Timer(TICK);
            this.updateTimer.Elapsed += Update;
            this.updateTimer.Start();
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
            ActivityController.GetInstance().MRE_Pause.WaitOne(); //suspend thread
            if (!this.gObjects[0].ContainsKey(gameObject.GetType()))
                this.gObjects[0].Add(gameObject.GetType(), new LinkedList<GameObject>());
            this.gObjects[0][gameObject.GetType()].AddLast(gameObject);
        }

        public bool DeleteGameObject(GameObject gameObject) {
            ActivityController.GetInstance().MRE_Pause.WaitOne();
            if ( !this.gObjects[0].ContainsKey(gameObject.GetType()) )
                return false;
            this.gObjects[0][gameObject.GetType()].Remove(gameObject);
            return true;
        }

        //=================================================PRIVATE=================================

        private void Update(object sender, EventArgs args) {
            bool focused = true;
            var aController = ActivityController.GetInstance();

            this.gameField.Invoke(new MethodInvoker( () => focused = this.gameField.Focused));

            aController.MRE_Pause.WaitOne(); //Suspend thread
            aController.Pause(true);

            foreach (var item in this.gObjects[0]) {
                if (typeof(Enemy).IsAssignableFrom(item.Key))
                    foreach (var elem in item.Value)
                        ((Enemy)elem).MoveTo(this.gObjects[0][typeof(Player)].First.Value.SpriteLocation);
                else if (typeof(IMoveable).IsAssignableFrom(item.Key))
                    foreach (var elem in item.Value)
                        ((IMoveable)elem).Move();
            }
            aController.Pause(false);
        }
    }
}
