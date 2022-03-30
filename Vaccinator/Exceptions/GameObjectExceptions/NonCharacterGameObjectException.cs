using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Exceptions.GameObjectExceptions {
    class NonCharacterGameObjectException : Exception {
        public NonCharacterGameObjectException() : base() { }
        public NonCharacterGameObjectException(string message) : base(message) { }
    }
}
