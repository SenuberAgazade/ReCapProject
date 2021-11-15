using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ CarId=1,BrandId=1,ColorId=1, Description="Porsche", ModelYear=2001, DailyPrice=300},
                new Car{ CarId=2,BrandId=2,ColorId=2, Description="Porsche", ModelYear=2002, DailyPrice=400},
                new Car{ CarId=3,BrandId=2,ColorId=3, Description="Porsche", ModelYear=2003, DailyPrice=500},
                new Car{ CarId=4,BrandId=3,ColorId=3, Description="Porsche", ModelYear=2004, DailyPrice=500},
                new Car{ CarId=5,BrandId=1,ColorId=1, Description="Porsche", ModelYear=2005, DailyPrice=400}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("car data added");
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
            Console.WriteLine("car data deleted");
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            Console.WriteLine("car data updated");
        }
    }
}
