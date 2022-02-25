using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Game.GameObjects {
    class BaseEnemy : Enemy {
        public BaseEnemy() {
            this.speed = 1;
            this.shotSpeed = 3;
            this.bulSpeed = 3;
            this.bulPower = [1, 1];
            this.health = 1;
        }
    }
}
