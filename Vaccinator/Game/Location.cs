using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Game {
    struct Location {
        private int x;
        private int y;

        public int X {
            get {
                return this.x;
            }
        }

        public int Y {
            get {
                return this.y;
            }
        }

        public Location(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public double GetRange(Location loc) {
            return Math.Sqrt(Math.Pow(this.x - loc.x, 2) + Math.Pow(this.y - loc.y, 2));
        }

        public int GetXDirect(Location loc) {
            return this.GetXDirect(loc.x);
        }

        public int GetXDirect(int x) {
            return (this.x - x) < 0 ? -1 : 1;
        }

        public int GetYDirect(Location loc) {
            return this.GetYDirect(loc.y);
        }

        public int GetYDirect(int y) {
            return (this.y - y) < 0 ? -1 : 1;
        }
    }
}
