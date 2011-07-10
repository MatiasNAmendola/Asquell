﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Objects;

namespace Asquell.Invokables
{
    [AsquellClass(AccessibleName="MEM")]
    public static class MemoryAccess
    {
        [AsquellMethod(AccessibleName = "Set", Exposed = true, NoMemoryBlock = false)]
        public static void SetMemory(MemoryBlock memory, AsquellObj from, AsquellObj to)
        {
            memory.ModifyVariable(to, from);
        }
        [AsquellMethod(AccessibleName = "Delete", Exposed = true, NoMemoryBlock = false)]
        public static void SetMemory(MemoryBlock memory, AsquellObj block)
        {
            memory.DeleteVariable(block);
        }
    }
}
