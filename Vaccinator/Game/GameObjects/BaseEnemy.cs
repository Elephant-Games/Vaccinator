using System.Drawing;
using Vaccinator.GUI;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    class BaseEnemy : Enemy {
        public const byte SPEED = 1;
        public const byte SHOT_SPEED = 3;
        public const byte BULLET_SPEED = 3;
        public static readonly byte[] BULLET_POWER = new byte[] { 1, 2 };
        public const byte HEALTH = 1;
        public static readonly Image skin = Properties.Resources.boss_enemy_b;

        public BaseEnemy(object gameField) :
            base(gameField as FormGame, skin, SPEED, SHOT_SPEED, BULLET_SPEED, BULLET_POWER, HEALTH) {
        }
    }
}
