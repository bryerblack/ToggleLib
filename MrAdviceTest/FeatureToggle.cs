using ArxOne.MrAdvice.Advice;
using MethodDecorator.Fody.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MrAdviceTest
{
    // [module: Interceptor]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class FeatureToggle : Attribute, IMethodAdvice
    {
        public bool Toggle { get; set; }

        public FeatureToggle(bool toggle) 
        {
            Toggle = toggle;
        }

        public void Advise(MethodAdviceContext context)
        {
            Console.WriteLine("A METHOD HAS BEEN INTERCEPTED");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(".");
                Thread.Sleep(1000);
            }

            var method = context.TargetMethod;
            var customAttribute = method.CustomAttributes;
            var toggle = customAttribute.FirstOrDefault()?.ConstructorArguments.First().Value;

            if (toggle is bool x)
                if (x)
                {
                    context.Proceed();
                } else
                    Console.WriteLine("METHOD OFF - CANCELING DETECTION");
        }
    }
}
