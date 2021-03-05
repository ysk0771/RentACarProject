using Core.Entities.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
       
        public static string ProductDelete = "Ürün silindi";

        public static string MaintenainceTime = "sistem bakımda";
       
        public static string ProductListed = "Ürünler listelendi";

        public static string ProductUpdate = "Ürün güncellendi";
        
        public static string CarsColorIdError = "Bir Üründeki limit sayısını açtınız";

        public static string ColorLimitExceded = "Renk tür sınırı dolmuştur";

        public static string AuthorizationDenied = "Yetkiniz yok.";
       
        public static string UserAlreadyExists = "Kullanıcı zaten çıktı/already exist";
        
        public static string PasswordError = "Şifre Hatalı";
        
        public static string UserRegistered = "Kullanıcı Kayıt edildi.";
        
        public static string UserNotFound = "kullanıcı bulunamadı";
        
        public static string AccessTokenCreated = "AcceseToken/başarılı şekilde token oluşturuldu";
        
        public static string SuccessfulLogin = "Başarılı bir Şekilde Giriş Yapıldı.";
    }
}
