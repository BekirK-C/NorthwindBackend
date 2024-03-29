﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi.";
        public static string ProductDeleted = "Ürün başarıyla silindi!";
        public static string ProductUpdated = "Ürün başarıyla güncellendi!";
        public static string ProductsListed = "Ürünler başarıyla listelendi.";
        public static string ProductCountOfCategoryError = "Bir kategoride 10 dan fazla urun olmamali";
        public static string ProductNameAlreadyExists = "Bu isimde zaten baska bir urun var";

        public static string UserAdded = "Kullanıcı başarıyla eklendi.";

        public static string CategoryAdded = "Kategori başarıyla eklendi!";
        public static string CategoryDeleted = "Kategori başarıyla silindi!";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi!";
        public static string CategoriesListed = "Kategoriler başarıyla listelendi!";

        public static string MaintenanceTime = "Sistem bakımda";
        public static string CategoryLimitExceeded = "Kategori limiti asildigi icin yeni urun eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayit oldu";
        public static string UserNotFound = "Kullanici bulunamadi";
        public static string PasswordError = "Sifre hatasi";

        public static string SuccessfulLogin = "Basarili giris";
        public static string UserAlreadyExists = "Kullanici mevcut";
        public static string AccessTokenCreated = "Token olusturuldu";

        public static string WrongLoggerType = "Hatalo Loglama Sınıfı";
        
    }
}
