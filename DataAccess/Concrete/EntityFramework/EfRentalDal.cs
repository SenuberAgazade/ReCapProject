using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityFrameworkRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cus in context.Customers on r.CustomerId equals cus.Id
                             join u in context.Users on cus.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 BrandName = b.BrandName,
                                 CustomerName = u.FirstName + ' ' + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };

                return result.ToList();
            }

        }
    }
}
