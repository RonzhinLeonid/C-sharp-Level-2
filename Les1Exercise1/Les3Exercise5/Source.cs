using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les3Exercise5
{
    public delegate void MyDelegate<T>(T arg);
    class Source
    {
        public event MyDelegate<object> Run;

        public void Start()
        {
            Console.WriteLine("RUN");
            if (Run != null) Run(this);
        }
    }
}
