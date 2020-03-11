using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore_3_0.Classes_Demo
{
    public class TestClass : ITestClass
    {
        public string GreetMe(string name)
        {
            return string.Format(CultureInfo.CurrentCulture,"Hello {0}", name);
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
