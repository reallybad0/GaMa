using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1810
{
    class Person
    {
        public string name = String.Empty;

        public Person(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }

        //public 
    }
}
