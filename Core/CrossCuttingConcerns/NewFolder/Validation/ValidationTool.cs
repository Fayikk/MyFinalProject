using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.NewFolder.Validation
{
    public static class ValidationTool//tek bir instance oluşturup kullanılabilir.
        //Bu yüzden static olarak tanımlamamızı yapalım.
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);//Validation context'i çağırıyoruz.
            
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
        }
    }
}
