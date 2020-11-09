using RefrigeratorSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RefrigeratorSimulator.Classes
{
    class ConsoleNotifier : INotify
    {
        public void Notify()
        {
            Debug.WriteLine("Ошибка лол");
        }
    }
}
