using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Urun basariyla eklendi";
        public static string ProductUpdated = "Urun basariyla guncellendi";
        public static string ProductDeleted = "Urun basariyla silindi";

        public static string CategoryAdded = "Kategori basariyla eklendi";
        public static string CategoryUpdated = "Kategori basariyla guncellendi";
        public static string CategoryDeleted = "Kategori basariyla silindi";

        public static string UserNotVerified = "Kullanici veya Sifre yanlis";
        public static string UserLoginSuccessful = "Kullanici girisi basarili";
        public static string UserAlreadyExist = "Kullanici zaten mevcut";
        public static string UserRegistered = "Kullanici kaydi basarili";
    }
}
