﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lld_console_app.DecoratorPattern
{
    public class Delight : BasePizza
    {
        public override int Cost()
        {
            return 120;
        }
    }
}
