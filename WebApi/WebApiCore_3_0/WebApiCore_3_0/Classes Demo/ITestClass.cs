using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore_3_0.Classes_Demo
{
    interface ITestClass
    {
        void SendMessage(string message);
        string GreetMe(string name);
    }
}
