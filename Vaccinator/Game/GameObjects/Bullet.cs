using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class Bullet : GameObject, IMoveable {
        protected byte power;
        
        public Bullet(FormGame gameField, System.Drawing.Image skin, byte power) : base(gameField, skin) {
            this.power = power;
        }

        public virtual void Move() {
            
        }

        public void Stop() {
            
        }
    }
}
