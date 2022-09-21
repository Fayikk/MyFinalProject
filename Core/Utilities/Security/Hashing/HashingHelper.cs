using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash
            (string password,out byte[] passwordHash, out byte[] passwordSalt)
        {
            //.Net'in kriptografi sınıflarından faydalanalım.
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//her kullanıcı için başka bir key oluşturulacaktır.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            //Burada yazılan kod verilen password değerinin salt ve hash değerini oluşturacaktır.
        
        }

        //Aşağıdaki ifadede gönderilen parametrelerdeki password ifadesi kullanıcın girdiği parola anlamına gelmektedir.
        //Kayıt oluşturduktan sonra giriş yaparken girdiği parola anlamına gelmektedir.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //Password Hash'i doğrula anlamına gelmektedir.
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //Oluşan değer bir byte arraydir.
                //Bu arrayleriin değerleri(referansları aynımı diye kontrol ederken) for döngüsü kullanırız
                for (int i = 0; i < computedHash.Length; i++)
                {

                    if (computedHash[i] != passwordHash[i]) 
                    {
                        return false;
                    }
                }
            }
            return true;
        
        
        }
    }
}
