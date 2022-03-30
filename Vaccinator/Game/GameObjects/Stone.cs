using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.Exceptions.GameObjectExceptions;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    class Stone : Bullet {
        private static readonly System.Drawing.Image SKIN = Properties.Resources.base_enemy_a;

        //=================================CONSTRUCTORS========================

        public Stone(object gameField) : this(gameField as FormGame, 0) {

        }

        public Stone(object gameField, byte speed) : base(gameField as FormGame, SKIN, getPower(), speed) {
            if (!(this is ThrownStone))
                base.updater.Dispose();
        }

        public override void Move() {
            if (this is ThrownStone)
                base.Move();
            else
                throw new NotMoveableObjectException($"Object {this} can't move in general!");
        }

        private static byte getPower() {
            return (byte)GameObject.random.Next(1, 3);
        }
    }
}
