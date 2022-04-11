using System.Drawing;
using Vaccinator.Exceptions.GameObjectExceptions;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    class Stone : Bullet {
        private static readonly System.Drawing.Image SKIN = Properties.Resources.base_enemy_a;

        //=================================CONSTRUCTORS========================

        public Stone(params object[] args) : this(args[0] as FormGame, (Point) args[1], 0, 0) {

        }

        public Stone(FormGame gameField, Point spawn, byte power, byte speed) : base(gameField, spawn, SKIN, power, speed) {
            if (!(this is ThrownStone))
                this.updater.Dispose();
        }

        public override void Move() {
            if (this is ThrownStone)
                base.Move();
            else
                throw new NotMoveableObjectException($"Object {this} can't move in general!");
        }

        protected override void findHited() {
            if (this is ThrownStone)
                base.findHited();
            else
                throw new NotMoveableObjectException($"Object {this} isn't a bullet!");
        }
    }
}
