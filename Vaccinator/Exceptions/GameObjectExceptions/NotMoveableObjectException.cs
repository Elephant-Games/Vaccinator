using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Exceptions.GameObjectExceptions {
    class NotMoveableObjectException : Exception {
        public NotMoveableObjectException() : base() { }
        public NotMoveableObjectException(string message) : base(message) { }
    }
}
