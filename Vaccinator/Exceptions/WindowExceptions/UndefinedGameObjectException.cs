using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Exceptions.WindowExceptions {
    class UndefinedGameObjectException : Exception {
        public UndefinedGameObjectException() : base() { }
        public UndefinedGameObjectException(string message) : base(message) { }
    }
}
