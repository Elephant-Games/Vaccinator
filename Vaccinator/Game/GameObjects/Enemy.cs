using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    abstract class Enemy : Character {
        public Enemy(FormMain gameField) : base(gameField) {

        }
    }
}
