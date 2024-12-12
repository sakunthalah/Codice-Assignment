using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class UserDefinedException : Exception
    {
        public UserDefinedException(string message) : base(message) { }

        public class UDNotFoundException : UserDefinedException
        {
            public UDNotFoundException(string message) : base(message)
            {
            }
        }

        public class UDBadRequesException : UserDefinedException
        {
            public UDBadRequesException(string message) : base(message)
            {
            }
        }
    }
}
