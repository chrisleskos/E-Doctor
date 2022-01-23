﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User Not Found!") { }
    }
}
