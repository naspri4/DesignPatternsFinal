﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal
{
    interface IWeaponBehavior
    {
        string weapon();
        int getDamageMin();
        int getDamageMax();
    }
}
