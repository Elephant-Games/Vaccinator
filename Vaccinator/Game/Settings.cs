using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Game {
    class Settings {
        private static Settings instance;

        private byte difficult;
        private bool isTwoPlayers;
        private Keys[] keys;
        private bool lang;

        private Settings() { }

        public static Settings GetInstance() {
            if (instance == null) {
                instance = new Settings();
            }
            return instance;
        }
        
        private class Keys { 
            private System.Windows.Forms.Keys up { get { return this.up; } set { this.up = value; } }
            private System.Windows.Forms.Keys down { get { return this.down; } set { this.down = value; } }
            private System.Windows.Forms.Keys right { get { return this.right; } set { this.right = value; } }
            private System.Windows.Forms.Keys left { get { return this.left; } set { this.left = value; } }
            private System.Windows.Forms.Keys shot { get { return this.shot; } set { this.shot = value; } }

            public Keys() {

            }
        }
    }
}
