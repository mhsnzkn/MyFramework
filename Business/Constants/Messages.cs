using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public const string ProductAdded = "Urun basariyla eklendi";
        public const string ProductUpdated = "Urun basariyla guncellendi";
        public const string ProductDeleted = "Urun basariyla silindi";

        public const string CategoryAdded = "Kategori basariyla eklendi";
        public const string CategoryUpdated = "Kategori basariyla guncellendi";
        public const string CategoryDeleted = "Kategori basariyla silindi";

        public const string UserNotVerified = "Kullanici veya Sifre yanlis";
        public const string UserLoginSuccessful = "Kullanici girisi basarili";
        public const string UserAlreadyExist = "Kullanici zaten mevcut";
        public const string UserRegistered = "Kullanici kaydi basarili";

        public const string AuthorizationDenied = "Yetkiniz yok";

        public const string ProductAlreadyExist = "Urun zaten bulunuyor";
    }
}
