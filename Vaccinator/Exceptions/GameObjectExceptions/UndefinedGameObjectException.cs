using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Exceptions.GameObjectExceptions {
    class UndefinedGameObjectException : Exception {
        public UndefinedGameObjectException() : base() { }
        public UndefinedGameObjectException(string message) : base(message) { }
    }
}
