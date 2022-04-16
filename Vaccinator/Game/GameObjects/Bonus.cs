using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class Bonus : GameObject {
        protected byte timeOfAct;
        private byte existenceTime;

        public Bonus(FormGame gameField, Image skin) : base(gameField, skin) {

        }

        public void Action(Player player) {

        }
    }
}
