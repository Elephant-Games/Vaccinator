using System;
using System.Collections.Generic;
using Vaccinator.Game.GameObjects;

namespace Vaccinator.Game {
    class Game {
        private static Game instance;

        private bool isGameOn;
        private LinkedList< Generator >[] generators = new LinkedList< Generator >[2];
        private Dictionary< Type, LinkedList<GameObject> >[] objects = new Dictionary< Type, LinkedList<GameObject> >[2];

        private Game() { //TODO: remake constructor
            this.generators[0] = new LinkedList< Generator >();
            this.objects[0] = new Dictionary< Type, LinkedList<GameObject> >();
        }

        public static Game GetInstance() {
            if (instance == null)
                instance = new Game();
            return instance;
        }

        public void AddGameObject(GameObject gameObject) {
            if (!this.objects[0].ContainsKey(gameObject.GetType()))
                this.objects[0].Add(gameObject.GetType(), new LinkedList<GameObject>());
            this.objects[0][gameObject.GetType()].AddLast(gameObject);
        }
    }
}
