using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SystemSettingRecommendationAttribute : Attribute
    {
        public string Recommendation { get; }

        public SystemSettingRecommendationAttribute(string recommendation)
        {
            Recommendation = recommendation;
        }
    }
}
