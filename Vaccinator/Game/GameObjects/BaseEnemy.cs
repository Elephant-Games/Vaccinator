using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    class BaseEnemy : Enemy {
        public const byte SPEED = 1;
        public const byte SHOT_SPEED = 3;
        public const byte BULLET_SPEED = 3;
        public static readonly byte[] BULLET_POWER = new byte[] { 1, 2 };
        public const byte HEALTH = 1;

        public BaseEnemy(FormMain gameField) : base(gameField,
            SPEED, SHOT_SPEED, BULLET_SPEED, BULLET_POWER, HEALTH) {
        }
    }
}
