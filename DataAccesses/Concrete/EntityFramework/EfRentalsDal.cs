using Core.DataAccesses.EntityFramework;
using DataAccesses.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesses.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rental, CarRentContext>, IRentalsDal
    {
        public List<RentalsDetailDTO> GetRentalsDetails()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result =
                    from r in context.Rentals
                    join car in context.Cars
                        on r.CarId equals car.Id
                    join c in context.Users on r.CustomerId equals c.Id
                    join b in context.Brands on car.BrandId equals b.Id
                    join u in context.Cars on c.Id equals u.Id
                    select new RentalsDetailDTO
                    {
                        Id = r.Id,
                        CarId = r.CarId,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                        FirstName = c.FirstName,
                        LastName = c.FirstName
                    };
                return result.ToList();
            }
        }
    }
}
