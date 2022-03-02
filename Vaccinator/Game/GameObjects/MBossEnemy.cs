﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    class MBossEnemy : Enemy{
        private const byte SPEED = 2;
        private const byte SHOT_SPEED = 2;
        private const byte BULLET_SPEED = 4;
        private static readonly byte[] BULLET_POWER = new byte[] { 1, 2 };
        private const byte HEALTH = 2;

        public MBossEnemy(FormMain gameField) : base(gameField) {
            this.speed = SPEED;
            this.shotSpeed = SHOT_SPEED;
            this.bulSpeed = BULLET_SPEED;
            this.bulPower = (byte)GameObject.random.Next(BULLET_POWER[0], BULLET_POWER[1] + 1);
            this.health = HEALTH;
        }
    }
}
