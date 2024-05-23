using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Exceptions
{
    public class UnsupportedException : Exception
    {
        public UnsupportedException(string message) : base(message){}

        public UnsupportedException(string message, Exception exception): base(message,exception){}
    }
}
