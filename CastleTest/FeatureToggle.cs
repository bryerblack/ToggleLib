using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleTest
{
    [System.AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    internal class FeatureToggle : Attribute
    {
        public bool Toggle { get; set; }
        public FeatureToggle(bool toggle)
        {
            Toggle = toggle;
        }
    }
}
