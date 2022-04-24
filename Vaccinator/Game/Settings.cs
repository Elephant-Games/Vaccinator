namespace Vaccinator.Game {
    class Settings {
        //settings = Settings.GetInstance();

        private static Settings instance;

        private byte difficult;
        private bool isTwoPlayers;
        private Keys[] keys;
        private bool lang;

        private Settings() {
        }

        public static Settings GetInstance() {
            if (instance == null) {
                instance = new Settings();
            }
            return instance;
        }

        public Keys[] SKeys {
            get {
                return this.keys;
            }
        }

        public void Load(bool isTwoPlayers) {
            this.difficult = 2;
            this.isTwoPlayers = false;
            this.lang = false;
            this.keys = new Keys[2];
            this.Load(this.isTwoPlayers);
            if (!isTwoPlayers) {
                this.keys[0] = new Keys(false);
            }
            else if(isTwoPlayers) {
                this.keys[1] = new Keys(true);
            }
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

            public Keys(bool isTwoPlayer) {
                this.Load(isTwoPlayer);
            }


            
            public void Load(bool isTwoPlayer) {
            if (!isTwoPlayer) {
                this.up = System.Windows.Forms.Keys.Up;
                this.down = System.Windows.Forms.Keys.Down;
                this.left = System.Windows.Forms.Keys.Left;
                this.right = System.Windows.Forms.Keys.Right;
                this.shot = System.Windows.Forms.Keys.Enter;
            }
            else if(isTwoPlayer) {
                this.up = System.Windows.Forms.Keys.W;
                this.down = System.Windows.Forms.Keys.S;
                this.left = System.Windows.Forms.Keys.A;
                this.right = System.Windows.Forms.Keys.D;
                this.shot = System.Windows.Forms.Keys.Space;
            }
            }
        }
    }
}
