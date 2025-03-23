using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ship
    {
        public List<Container> containers;
        public string name;

        public Ship(string name)
        {
            this.name = name;
        }

        public void addContainers(List<Container> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                containers.Add(list[i]);
            }
        }
    }
}
