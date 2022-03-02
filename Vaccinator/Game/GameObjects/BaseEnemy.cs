using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Game.GameObjects {
    class BaseEnemy : Enemy {
        private const byte SPEED = 1;
        private const byte SHOT_SPEED = 3;
        private const byte BULLET_SPEED = 3;
        private static readonly byte[] BULLET_POWER = new byte[] { 1, 2 };
        private const byte HEALTH = 1;

        public BaseEnemy(byte speed, byte shotSpeed, byte bulSpeed, byte health) : base(speed, shotSpeed, bulSpeed, health) {
            this.speed = SPEED;
            this.shotSpeed = SHOT_SPEED;
            this.bulSpeed = BULLET_SPEED;
            this.bulPower = (byte)GameObject.random.Next(BULLET_POWER[0], BULLET_POWER[1] + 1);
            this.health = HEALTH;
        }
    }
}
