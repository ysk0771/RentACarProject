using DataAccesses.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccesses.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Cars entity)
        {
            //using bittiği anda garbage collector tarafından hafızadan atılmasını sağlar 
            using (CarRentContext context=new CarRentContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added ;
                context.SaveChanges();
            }
        }

        public void Delete(Cars entity)
        {
            using(CarRentContext context=new CarRentContext())
            {
                var deleteEntity = context.Remove(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public Cars Get(Expression<Func<Cars, bool>> filter)
        {
            using (CarRentContext context=new CarRentContext())
            {
                return context.Set<Cars>().SingleOrDefault(filter);
            }
        }

        public List<Cars> GetAll(Expression<Func<Cars, bool>> filter = null)
        {
            using (CarRentContext context=new CarRentContext())
            {
                return filter == null 
                    ? context.Set<Cars>().ToList() 
                    : context.Set<Cars>().Where(filter).ToList();
            }
        }

        public void Update(Cars entity)
        {
            using (CarRentContext context=new CarRentContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
