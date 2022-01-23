using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Exceptions
{
    public class UsernameAlreadyTaken : Exception
    {
        public UsernameAlreadyTaken() : base("Username is already used by another user!") { }
    }
}
