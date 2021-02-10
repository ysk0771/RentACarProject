using DataAccesses.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccesses.Concrete.EntityFramework
{
    public class EfBrandDal : IBranDal
    {
        public void Add(Brands entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brands entity)
        {
            throw new NotImplementedException();
        }

        public Brands Get(Expression<Func<Brands, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brands> GetAll(Expression<Func<Brands, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Brands entity)
        {
            throw new NotImplementedException();
        }
    }
}
