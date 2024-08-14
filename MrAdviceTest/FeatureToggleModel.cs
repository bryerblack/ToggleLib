using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrAdviceTest
{
    [Table("featuretoggles")]
    [PrimaryKey(nameof(ToggleId))]
    public class FeatureToggleModel
    {
        public string ToggleId;
        public bool Toggle { get; set; }
        [NotMapped]
        public FeatureToggleType FeatureToggleType { get; set; }
        [NotMapped]
        public DateOnly CreationDate { get; set; }
        [NotMapped]
        public Dictionary<string, List<string>> AdditionalRules { get; set; }

        public FeatureToggleModel() { }

        public FeatureToggleModel(string toggleId, bool toggle, FeatureToggleType featureToggleType, DateOnly creationDate) 
        {
            ToggleId = toggleId;
            Toggle = toggle;
            FeatureToggleType = featureToggleType;
            CreationDate = creationDate;
        }
    }

    public enum FeatureToggleType
    {
        RELEASE,
        EXPERIMENT,
        PERMISSIONING,
        OPS
    }
}
