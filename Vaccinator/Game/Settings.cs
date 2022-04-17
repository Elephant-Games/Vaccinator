using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Game {
    class Settings {
        //settings = Settings.GetInstance();

        private static Settings instance;

        private byte difficult;
        private bool isTwoPlayers;
        private Keys[] keys;
        private bool lang;

        public Settings(byte difficult = 2, bool twoPlayers = false, bool lan = true) {
            this.difficult = difficult;
            this.isTwoPlayers = twoPlayers;
            this.lang = lan;
            this.keys = new Keys[2];
            this.Load(this.isTwoPlayers);
        }

        public static Settings GetInstance() {
            if (instance == null) {
                instance = new Settings();
            }
            return instance;
        }

        public void Load(bool isTwoPlayers) {

            if (isTwoPlayers) {
                
            }
            else {
                this.Up = System.Windows.Forms.Keys.Up;
                this.Down = System.Windows.Forms.Keys.Down;
                this.Up = System.Windows.Forms.Keys.Left;
                this.Up = System.Windows.Forms.Keys.Right;
                this.Up = System.Windows.Forms.Keys.Space;
            }
        }

        public System.Windows.Forms.Keys Up {
            get {
                return this.Up;
            }
        }
        public System.Windows.Forms.Keys Down {
            get {
                return this.Down;
            }
        }
        public System.Windows.Forms.Keys Right {
            get {
                return this.Right;
            }
        }
        public System.Windows.Forms.Keys Left {
            get {
                return this.Left;
            }
        }
        public System.Windows.Forms.Keys Shot {
            get {
                return this.Shot;
            }
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
                this.Load();
            }

            public void Load() {
                this.up = System.Windows.Forms.Keys.Up;
                this.down = System.Windows.Forms.Keys.Down;
                this.left = System.Windows.Forms.Keys.Left;
                this.right = System.Windows.Forms.Keys.Right;
                this.shot = System.Windows.Forms.Keys.Space;
            }
        }
    }
}
