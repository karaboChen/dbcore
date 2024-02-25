using dbcore.Models;
using System.ComponentModel.DataAnnotations;

namespace dbcore.Vail
{
    public class TAAttribute :ValidationAttribute
    {
        //Attribute  加上這格可以省略後綴詞
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   

            //2種寫法都可以

            //RoadContext  _roadContext = (RoadContext) validationContext.GetService(typeof(RoadContext));
            RoadContext _roadContext = validationContext.GetService<RoadContext>();
              

            //這個會拿到 設定的class
            var cc =   validationContext.ObjectInstance;

            //利用 GetType()    typeof(對應的class)
            if (cc.GetType() == typeof(Paw)) 
            { 
            }


            var data = (string)value;

            if (data == "string")
            {
                return new ValidationResult("重複");

            }
            return ValidationResult.Success;

        }


    }
}
