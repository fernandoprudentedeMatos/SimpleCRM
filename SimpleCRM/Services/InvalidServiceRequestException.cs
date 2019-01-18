using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM.Services
{
    [Serializable]
    public class InvalidServiceRequestException : Exception
    {
        public InvalidServiceRequestException(string message) : base(message) { }
    }
}
