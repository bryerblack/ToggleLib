using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrAdviceTest
{
    public interface ITest
    {
        void TestMethod();
        void TestMethodOn();
        void TestMethodOff();
    }

    public class Test : ITest
    {
        public virtual void TestMethod()
        {
            Console.WriteLine("APPLICATION START. . .");
            TestMethodOn();
            TestMethodOff();
            Console.WriteLine("NOW STARTING SECOND BATCH. . .");
            TestMethodOff();
            TestMethodOn();
        }

        [FeatureToggle(true)]
        public virtual void TestMethodOn()
        {
            Console.WriteLine("enter TesteMethod() - On");
        }

        [FeatureToggle(false)]
        public virtual void TestMethodOff()
        {
            Console.WriteLine("THIS SOULD NOT HAVE HAPPENED");
            throw new Exception();
        }
    }
}
