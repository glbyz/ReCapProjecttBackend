using Business.Concrete;
using Business.Constants;
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
            //CarTest();
            //BrandTest();
            //ColorTest();
            //UserAdded();




            



            Console.Read();

        }

        private static void UserAdded()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Add(new User
            {
                FirstName = "Bugrahan",
                LastName = "Çeker",
                Email = "bugrahanceker17@hotmail.com",
                Password = "baç17baç"
            });

            Console.WriteLine(Messages.Added);
            //var result = userManager.Add(new User());
            //if (result.Success==true)
            //{

            //    Console.WriteLine(Messages.Added);
            //}
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Füme" });
            colorManager.Update(new Color { ColorId = 1, ColorName = "Metal" });
            colorManager.Delete(new Color { ColorId = 2, ColorName = "Mavi" });

            var result = colorManager.GetAll();
            if (result.Success==true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            
            var result1 = colorManager.GetById(5);
            Console.WriteLine(result1.Data.ColorName);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand { BrandName = "Ford" });

            brandManager.Update(new Brand { BrandId = 10, BrandName = "Fordddd" });

            brandManager.Delete(new Brand { BrandId = 10, BrandName = "Fordddd" });

            var result = brandManager.GetById(2);
            Console.WriteLine(result.Data.BrandName);



            var result2 = brandManager.GetAll();
            foreach (var brand in result2.Data)
            {
                Console.WriteLine(brand.BrandName);
            }

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car { BrandId = 2, ColorId = 3, ModelYear = 2014, DailyPrice = 220, Description = "Manuel" };
            Car car2 = new Car { BrandId = 1, ColorId = 2, ModelYear = 2017, DailyPrice = 250, Description = "O" };
            Car car3 = new Car { BrandId = 3, ColorId = 4, ModelYear = 2019, DailyPrice = 0, Description = "Otomatik" };
            Car car4 = new Car { BrandId = 5, ColorId = 5, ModelYear = 2021, DailyPrice = 300, Description = "Manuel" };

            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            carManager.Add(car4);




            var result = carManager.GetCarsByBrandId(2);
            foreach (var car in result.Data)
            {
                Console.WriteLine("Adı : " + car.CarName + " " + "Model Yılı: " + car.ModelYear + " " + "Günlük Fiyatı : " + car.DailyPrice + " " + "Açıklama : " + car.Description);
            }



            var result2 = carManager.GetCarsByColorId(4);
            foreach (var car in result2.Data)
            {
                Console.WriteLine("Adı : " + car.CarName + " " + "Model Yılı: " + car.ModelYear + " " + "Günlük Fiyatı : " + car.DailyPrice + " " + "Açıklama : " + car.Description);
            }


            var result3 = carManager.GetAll();
            foreach (var car in result3.Data)
            {
                Console.WriteLine(car.BrandId);
                Console.WriteLine(car.ColorId);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.Description);
                Console.WriteLine(car.ModelYear);
            }


            var result4 = carManager.GetCarDetails();

            foreach (var car in result4.Data)
            {
                Console.WriteLine(car.BrandName + " " + car.CarName + " " + car.ColorName +  " " + car.DailyPrice);
            }

        }
    }
}
