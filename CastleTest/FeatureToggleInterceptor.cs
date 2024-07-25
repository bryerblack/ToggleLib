using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleTest
{
    public class FeatureToggleInterceptor : IInterceptor
    {
        //private T _decorated;

        public FeatureToggleInterceptor() : base() {}

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("A METHOD HAS BEEN INTERCEPTED");
            for (int i = 0; i<3; i++) 
            {
                Console.WriteLine(".");
                Thread.Sleep(1000);
            }

            var derivedMethod = invocation.Method;
            var attributes = Attribute.GetCustomAttributes(derivedMethod);
            var leto = attributes.Where(a => a is FeatureToggle).FirstOrDefault();
            if (leto is FeatureToggle x)
            {
                if (x.Toggle)
                {
                    invocation.Proceed();
                } else
                    Console.WriteLine("METHOD OFF - CANCELING DETECTION");
            } else
                invocation.Proceed();
        }
    }
}
