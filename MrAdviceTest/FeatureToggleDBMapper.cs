using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrAdviceTest
{
    public class FeatureToggleDBMapper : FeaturToggleMapper
    {
        public override FeatureToggleModel Map(string featureToggleId)
        {
            return new FeatureToggleModel("featureToggleId", false, FeatureToggleType.RELEASE, DateOnly.FromDateTime(DateTime.Now));
        }
    }
}
