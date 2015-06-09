﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal
{
    class Dagger : Item
    {
        public Dagger()
        {
            name = "Dagger";
            damageMax = 5;
            damageMin = 1;
        }
    }
}