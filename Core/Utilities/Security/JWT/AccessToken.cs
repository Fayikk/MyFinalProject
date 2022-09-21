using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //Jetonun bu 
        public DateTime Expiration { get; set; } //Jetonun bu tarihte bitecek anlmaına gelmektedir.

    }
}
