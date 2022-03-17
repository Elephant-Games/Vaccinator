using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Exceptions.WindowExceptions {
    class PointOutOfRangeException : ArgumentException {
        private Point point;

        public Point Point {
            get {
                return this.point;
            }
        }

        public PointOutOfRangeException() : base() { }
        public PointOutOfRangeException(string message) : base(message) { }
        public PointOutOfRangeException(string message, Point point) : this(message) {
            this.point = point;
        }
    }
}
