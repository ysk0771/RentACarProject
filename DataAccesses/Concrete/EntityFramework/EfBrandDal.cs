using Core.DataAccesses.EntityFramework;
using DataAccesses.Abstract;
using Entities.Concrete;

namespace DataAccesses.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentContext>, IBranDal
    {
       
    }
}
