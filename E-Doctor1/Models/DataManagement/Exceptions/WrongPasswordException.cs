using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base("Wrong Password") { }
    }
}
