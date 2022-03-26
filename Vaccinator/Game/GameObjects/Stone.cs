using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    class Stone : Bullet, IPickable {
        private static readonly System.Drawing.Image SKIN = Properties.Resources.base_enemy_a;

        private bool isDropped;
        private bool isPicked;

        public bool IsDropped {
            get {
                return this.isDropped;
            }
        }

        //=================================CONSTRUCTORS========================

        public Stone(object gameField) : base(gameField as FormGame, SKIN, getPower()) {
            this.isDropped = false;
        }

        public Stone(FormGame gameField, bool isDropped) : this(gameField) {
            this.isDropped = isDropped;
        }

        private static byte getPower() {
            return (byte)GameObject.random.Next(1, 3);
        }

        public override void Move() {
            if (this.isDropped)
                base.Move();
        }

        public void Pick(Player player) {
            this.Hide();
            this.isPicked = true;
        }
    }
}
