using Core.DataAccesses.EntityFramework;
using DataAccesses.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccesses.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Colors, CarRentContext>, IColorDal
    {
      
    }
}
