using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Game.GameObjects {
    abstract class Character : GameObject {

        protected byte speed;

        protected byte shotSpeed;

        protected byte bulSpeed;

        protected byte[,] bulPower;

        protected byte health;
    }
}
