using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Game.GameObjects {
    class MBossEnemy : Enemy{
        public MBossEnemy() {
            this.speed = 2;
            this.shotSpeed = 2;
            this.bulSpeed = 4;
            this.bulPower = [1, 2];
            this.health = 2;
        }
    }
}
