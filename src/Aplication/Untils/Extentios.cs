using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Untils
{
    internal class Extentios
    {
    }
    public class ObjectNotFound : Exception
    {
        public ObjectNotFound(string message) : base(message) { }
    }

    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string message) : base(message) { }
    }
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message) : base(message) { }
    }
    public class ErrorMassage : Exception
    {
        public ErrorMassage(string message) : base(message) { }
    }
    public class ObjectAlreadyExistException : Exception
    {
        public ObjectAlreadyExistException(string message) : base(message) { }
    }
    public class NotPermissionException : Exception
    {
       public NotPermissionException(string message) : base(message) { }
    }

}
