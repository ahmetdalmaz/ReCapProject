using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarNameInvalid = "Araç ismi 2 karakterden fazla olmalıdır.";
        public static string CarPriceInvalid = "Fiyat 0 tl olamaz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Araçlar Listelendi";



        public static string EmailInvalid = "Lütfen geçerli bir email giriniz";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UsersListed = "Kullanıcılar Listelendi";


        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomersListed = "Müşteri Listelendi";



        public static string RentalAdded = "Kullanıcı Eklendi";
        public static string RentalDeleted = "Kullanıcı Silindi";
        public static string RentalUpdated = "Kullanıcı Güncellendi";
        public static string RentalsListed = "Kullanıcılar Listelendi";
        public static string RentalAddedError= "Araç kiraya verilemez.Henüz teslim edilmemiştir";
        public static string RentalReturnDateUpdated= "Araç teslim edildi";
        public static string RentalReturnDateError = "Araç zaten teslim edilmiş";

    }
}
