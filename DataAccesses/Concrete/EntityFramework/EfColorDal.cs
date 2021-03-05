using Core.DataAccesses.EntityFramework;
using DataAccesses.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;


namespace DataAccesses.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarRentContext>, IColorDal
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
