using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{ //Constants klasörü içerisindeyiz ve bu klasörde
    //Projemizle ilgili değişmez sabitleri tutarız

    public static class Messages//classı kullanırken sürekli olarak new'lemek için static bir class tanımlaması yapıyoruz.
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintanceTime = "Sistem Bakımda";
        public static string Success = "Listelendi";
        public static string ListId = "Listed";
        public static string NotSuccess = "Başarısız";
        public static string UnitPriceInvalid = "Geçersiz";
        //Temel mesajlarımızı buraya koyuyoruz.
    }
}
