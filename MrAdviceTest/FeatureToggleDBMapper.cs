using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MrAdviceTest
{
    public class FeatureToggleDBMapper : FeaturToggleMapper
    {
        public ApplicationDbContext Context { get; set; }
        public readonly DbContextOptions<ApplicationDbContext> contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseSqlServer(@"Server=DESKTOP-IPRIRSK\SQLEXPRESS;Database=Test;ConnectRetryCount=0;Integrated Security=SSPI;Integrated Security=true;TrustServerCertificate=True")
           .Options;

        public override FeatureToggleModel Map(string featureToggleId)
        {
            Context = new ApplicationDbContext(contextOptions);

            var featureToggle = Context.featureToggleModels.FirstOrDefault(x => x.ToggleId.Equals(featureToggleId));
            if (featureToggle == null)
            {
                return new FeatureToggleModel()
                {
                    ToggleId = featureToggleId,
                    Toggle = false,
                    
                };
            }

            Dictionary<string, List<string>>? ruleString = null;
            if (featureToggle.AdditionalRulesJson != null)
            {
                ruleString = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(featureToggle.AdditionalRulesJson);
            }
            return new FeatureToggleModel(
                featureToggle.ToggleId,
                featureToggle.Toggle,
                featureToggle.FeatureToggleType,
                featureToggle.CreationDate,
                ruleString);
        }
    }
}
