using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.GUI;

namespace Vaccinator.Game.GameObjects {
    abstract class Enemy : Character {

        protected Enemy(FormMain gameField, Image skin, byte speed, byte shotSpeed, byte bulSpeed, byte[] bulPower, byte health) :
            base(gameField, skin, speed, shotSpeed, bulSpeed, getBulletPower(bulPower), health) {

        }

        private static byte getBulletPower(byte[] bulPow) {
            return (byte)GameObject.random.Next(bulPow[0], bulPow[1]);
        }
    }
}
