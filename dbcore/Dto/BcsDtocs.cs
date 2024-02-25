using dbcore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dbcore.Dto
{
    public class BcsDtocs :IValidatableObject
    {
        
        public string name { get; set; }

        public string ssv { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            RoadContext _roadContext = validationContext.GetService<RoadContext>();

            var aa = name;

            yield return ValidationResult.Success;
        }
    }
}
