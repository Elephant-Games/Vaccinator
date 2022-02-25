using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Game.GameObjects {
    class BossEnemy : Enemy {
        public BossEnemy() {
            this.speed = 2;
            this.shotSpeed = 1;
            this.bulSpeed = 5;
            this.bulPower = [2, 4];
            this.health = 5;
        }
    }
}
