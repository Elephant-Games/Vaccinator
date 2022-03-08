using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    abstract class Character : GameObject {
        private byte speed;
        private byte shotSpeed;
        private byte bulSpeed;
        private byte bulPower;
        private byte health;

        protected Character(FormMain gameField, Image sprite, byte speed, byte shotSpeed, byte bulSpeed, byte bulPower, byte health) :
            base(gameField, sprite) {
            
            this.speed = speed;
            this.shotSpeed = shotSpeed;
            this.bulSpeed = bulSpeed;
            this.bulPower = bulPower;
            this.health = health;
        }
    }
}
