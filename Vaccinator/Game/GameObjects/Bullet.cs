using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaccinator.GUI.GameWindow;

namespace Vaccinator.Game.GameObjects {
    abstract class Bullet : MovingObject {

        protected byte power;

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

            base.updater.Start();
        }

        public override void Move() {
            base.Move();
            this.FindHited();
        }

        protected async void FindHited() {
            await Task.Run(() => {
                var game = Game.GetInstance();
                Enemy enemy = game.FindIntersectedEnemy(this);
                if (enemy != null) {
                    enemy.Hit(this);
                    this.Destroy();
                }
            });
        }
    }
}
