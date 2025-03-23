using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class RefrigeratedContainer : Container
    {
        private double temperature;

        public RefrigeratedContainer(double temperature) 
        {
            this.temperature = temperature;
            Type = 'R';
            SerialNumber = $"KON-{Type}-{lastNumber}";
        }



    }
}
