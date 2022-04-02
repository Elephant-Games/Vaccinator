using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class Bullet : MovingObject {

        protected byte power;
        protected Point shift;

        //=======================================GETTERS/SETTERS=============================================

        public byte Power {
            get {
                return this.power;
            }
        }

        //=========================================CONSTRUCTORS==============================================
        
        public Bullet(FormGame gameField, System.Drawing.Image skin, byte power, byte speed)
            : base(gameField, skin, speed) {
            this.power = power;
        }

        public override void Move() {
            this.findHited();
            this.isEndMove();
            base.Move();
        }

        protected virtual void isEndMove() {
            if (this.SpriteLocation.X < 0 || this.SpriteLocation.X > this.gameField.Width
                || this.SpriteLocation.Y < 0 || this.SpriteLocation.Y > this.gameField.Height) {
                
                this.Destroy();
            }
        }

        public override void Destroy(object sender = null, EventArgs args = null) {
            base.Destroy(sender, args);
        }

        protected async virtual void findHited() {
            await Task.Run(() => {
                var enemy = Game.GetInstance().FindIntersectedEnemy(this);
                if (enemy != null) {
                    enemy.Hit(this);
                    this.Destroy();
                }
            });
        }
    }
}
