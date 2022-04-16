using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinator.Exceptions.WindowExceptions {
    class IncompleteInitException : Exception {
        public IncompleteInitException() : base() { }
        public IncompleteInitException(string message) : base(message) { }
    }
}
