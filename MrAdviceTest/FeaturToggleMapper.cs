using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrAdviceTest
{
    public abstract class FeaturToggleMapper
    {
        public abstract FeatureToggleModel Map(string featureToggleId);
    }
}
