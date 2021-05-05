using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı";
        public static string NameInvalid = "Geçersiz İsim";
        public static string Deleted = "Silme işlemi başarılı";
        public static string Updated = "Güncelleme işlemi başarılı ";
        public static string Listed = "Listeleme işlemi başarılı";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string OperationFailed = "Araç Mevcut Değil. ";
        public static string ImageLimitExceded="Resim Ekleme Limiti Aşıldığı İçin Yeni Resim Eklenemiyor";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string SuccessfulLogin="Başarılı Giriş";
        public static string PasswordError="Şifre Hatalı";
        public static string UserAlreadyExists="Kullanıcı Zaten Mevcut";
        public static string AccessTokenCreated= "Access token başarıyla oluşturuldu";
        internal static string UserRegistered= "Kullanıcı başarıyla kaydedildi";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
    }
}
