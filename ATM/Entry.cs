﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Entry
    {
        static void Main(string[] args)
        {

            ATM atmApp = new ATM();
            atmApp.InitializeData();
            atmApp.Run();

        }
    }
}
