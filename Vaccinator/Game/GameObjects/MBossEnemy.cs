using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    class MBossEnemy : Enemy{
        public const byte SPEED = 2;
        public const byte SHOT_SPEED = 2;
        public const byte BULLET_SPEED = 4;
        public static readonly byte[] BULLET_POWER = new byte[] { 1, 2 };
        public const byte HEALTH = 2;
        public static readonly Image skin = Properties.Resources.base_enemy_a; //TODO: other enemy

        public MBossEnemy(FormMain gameField) :
            base(gameField, skin, SPEED, SHOT_SPEED, BULLET_SPEED, BULLET_POWER, HEALTH) {
        }
    }
}
