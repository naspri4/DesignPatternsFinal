﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal
{
    public interface IAbility
    {
        String ability(ref Party party);
        String getName();
    }
}
