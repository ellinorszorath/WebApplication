﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dejtingsida.Controllers
{
    public class Start : Controller
    {
        public Boolean inloggad= false;
        public Boolean kollaOmInloggad()
        {
            return true;
            return false;
        }
    }
}
