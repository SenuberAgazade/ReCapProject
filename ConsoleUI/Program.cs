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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} - {1} - {2} - {3}",car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
            //carManager.Add(new Car { CarId = 6, CarName = "t", ModelYear = 2006, DailyPrice = 0, BrandId = 1, ColorId = 5 });


            Console.ReadKey();
        }
    }
}
