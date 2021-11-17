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
            //CarTest();

            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "testname", LastName = "testsurname", Email = "test@gamil.com", Password = "12345" });

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1, CompanyName = "CompanyL" });

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result=rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 11, 17), ReturnDate = new DateTime(2021, 11, 19) });

            Console.WriteLine(result.Message);




            Console.ReadKey();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
            //carManager.Add(new Car { CarId = 6, CarName = "t", ModelYear = 2006, DailyPrice = 0, BrandId = 1, ColorId = 5 });
        }
    }
}
