using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Game.GameObjects {
    abstract class Bonus : GameObject {
        protected byte timeOfAct;
        private byte existenceTime;

        public void Action(player: Player) {

        }
    }
}
