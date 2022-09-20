using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //Credentials bir siteme girmek için elimizde olanlardır.Kullanıcı adı ve parolamızdır.
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);
            
        }
    }
}
