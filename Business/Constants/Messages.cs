using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public static string ProductCountOfCategory = "Kategoride fazla ürün bulunmaktadır";
        public static string ProductNameAlreadyExist="Aynı ürün isminde başka ürün bulunmaktadır";
        public static string OverloadingCategory="Kategori aşırı yüklendi";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi" ;
        public static string UserRegistered = "kullanıcı zaten kayıtlı"  ;
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Başarıyla Giriş Yapıldı" ;
        public static string UserAlreadyExists = "Kullanıcı zten var";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        //Temel mesajlarımızı buraya koyuyoruz.
    }
}
