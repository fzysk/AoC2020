using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    internal enum Operations
    {
        /// <summary>
        /// Do nothing
        /// </summary>
        nop,

        /// <summary>
        /// Add +x
        /// </summary>
        acc,

        /// <summary>
        /// Jump +/- x lines
        /// </summary>
        jmp, 
    }
}
