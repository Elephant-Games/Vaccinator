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

        public class Keys {
            private System.Windows.Forms.Keys up;
            private System.Windows.Forms.Keys down;
            private System.Windows.Forms.Keys right;
            private System.Windows.Forms.Keys left;
            private System.Windows.Forms.Keys shot;

            public System.Windows.Forms.Keys Up {
                get {
                    return this.up;
                }

                set {
                    this.up = value;
                }
            }
            public System.Windows.Forms.Keys Down {
                get {
                    return this.down;
                }

                set {
                    this.down = value;
                }
            }
            public System.Windows.Forms.Keys Right {
                get {
                    return this.right;
                }

                set {
                    this.right = value;
                }
            }
            public System.Windows.Forms.Keys Left {
                get {
                    return this.left;
                }

                set {
                    this.left = value;
                }
            }
            public System.Windows.Forms.Keys Shot {
                get {
                    return this.shot;
                }

                set {
                    this.shot = value;
                }
            }

            public Keys() {

            }
        }
    }
}
