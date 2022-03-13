using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.GUI.Settings {
    class Settings {
        private static Settings setting;
        private Settings() { }
        public static Settings getInstance() {
            if (setting == null) {
                setting = new Settings();
            }
            return setting;
        }
        private byte difficult;
        private bool isTwoPlayers;
        private Keys[] keys;
        private bool lang;
        private static Settings instance;
       
        private class Keys {
            private Keys up;
            private Keys down;
            private Keys right;
            private Keys left;
            private Keys shot;
            }

        public static Settings GetInstance() {

        }
    }
}
