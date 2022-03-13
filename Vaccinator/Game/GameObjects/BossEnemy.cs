using System.Drawing;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    class BossEnemy : Enemy {
        public const byte SPEED = 2;
        public const byte SHOT_SPEED = 1;
        public const byte BULLET_SPEED = 5;
        public static readonly byte[] BULLET_POWER = new byte[] { 1, 2 };
        public const byte HEALTH = 5;
        public static readonly Image skin = Properties.Resources.base_enemy_a; //TODO: other enemy

        public BossEnemy(object gameField) :
            base(gameField as FormMain, skin, SPEED, SHOT_SPEED, BULLET_SPEED, BULLET_POWER, HEALTH) {
        }
    }
}
