using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Entities.Concrete.Brand { Name = "BMW" });
            //brandManager.Add(new Entities.Concrete.Brand { Name = "Mercedes" });
            //brandManager.Add(new Entities.Concrete.Brand { Name = "Renault" });
            //brandManager.Add(new Entities.Concrete.Brand { Name = "Toyota" });
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Entities.Concrete.Color { Name = "Kırmızı" });
            //colorManager.Add(new Entities.Concrete.Color { Name = "Siyah" });
            //colorManager.Add(new Entities.Concrete.Color { Name = "Beyaz" });

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.Add(new Rental { CustomerId = 1, CarId = 1, RentDate = DateTime.Now });
            var result = rentalManager.UpdateReturnDate(2);
            Console.WriteLine(result.Message);



            //CarManager carManager = new CarManager(new EfCarDal());
          
            //var result = carManager.GetAll();
            //if (result.Success==false)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //foreach (var item in result.Data)
            //  {
            //    Console.WriteLine(item.Description);
            //  }
            //    Console.WriteLine(result.Message);

            //}

            //carManager.Add(new Entities.Concrete.Car { ColorId = 1, BrandId = 1, DailyPrice = 350, ModelYear = 2015, Description = "araba2" });
            //carManager.Add(new Entities.Concrete.Car { ColorId = 2, BrandId = 3, DailyPrice = 275, ModelYear = 2016, Description = "araba3" });
            //carManager.Add(new Entities.Concrete.Car { ColorId = 3, BrandId = 2, DailyPrice = 450, ModelYear = 2014, Description = "araba4" });
            //carManager.Add(new Entities.Concrete.Car { ColorId = 2, BrandId = 3, DailyPrice = 730, ModelYear = 2019, Description = "araba5" });
            //carManager.Add(new Entities.Concrete.Car { ColorId = 2, BrandId = 4, DailyPrice = 500, ModelYear = 2020, Description = "araba5" });



            //foreach (var item in carManager.GetCarDetails())
            //{
            //    Console.WriteLine("araba : {0} günlük fiyat: {1} markası : {2}", item.Description, item.DailyPrice,item.BrandName);
            //}




        }
    }
}
