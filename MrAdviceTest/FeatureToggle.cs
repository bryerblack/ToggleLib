using ArxOne.MrAdvice.Advice;
using MethodDecorator.Fody.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public string FeatureToggleId { get; set; }
        public FeatureToggleDBMapper _featureToggleDBMapper = new FeatureToggleDBMapper();

        public FeatureToggle(string featureToggleId) 
        {
            FeatureToggleId = featureToggleId;
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
            var toggleId = customAttribute.FirstOrDefault()?.ConstructorArguments.First().Value;

            if (toggleId is string x) {
                var model = _featureToggleDBMapper.Map(x);
                if (model.Toggle)
                {
                    context.Proceed();
                } else
                    Console.WriteLine("METHOD OFF - CANCELING DETECTION");
            }
        }
    }
}
