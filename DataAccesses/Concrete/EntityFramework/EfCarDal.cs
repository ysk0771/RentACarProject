using Core.DataAccesses.EntityFramework;
using DataAccesses.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccesses.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Cars, CarRentContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (CarRentContext context= new CarRentContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.Id
                             select new CarDetailDTO { ModelYear=p.ModelYear,Descriptions = p.Descriptions,
                                 DailyPrice = p.DailyPrice,
                                 BrandId = c.Id
                             };
                return result.ToList();
            }
        }
    }
}
