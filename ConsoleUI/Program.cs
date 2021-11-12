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
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarName);
            //}
            carManager.Add(new Car { CarId = 6, CarName = "t", ModelYear = 2006, DailyPrice = 0, BrandId = 1, ColorId = 5 });
            

            Console.ReadKey();
        }
    }
}
