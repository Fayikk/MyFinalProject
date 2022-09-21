using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    //Security key helper byte array olarak dönüştürmeye yaramaktadır. 
    public class SecurityKeyHelper
    {
        //İçerisinde şifreleme olan sistemlerde herşeyi byte[] array olarak vermemiz gerekmektedir.         
        public static SecurityKey CreateSecurityKey(string SecurityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
            
        }
    
    }
}
