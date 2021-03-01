using Core.DataAccesses.EntityFramework;
using DataAccesses.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccesses.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Colors, CarRentContext>, IColorDal
    {
        public List<ColorDetailDTO> GetColorDetails()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from p in context.Colors
                             join c in context.Cars
                             on p.Id equals c.ColorId
                             select new ColorDetailDTO 
                             {
                                 Id = p.Id,
                                 ColorName=p.ColorName

                             };
                return result.ToList();
            }
        }
    }
}
