
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccesses
{ //generic constraint
    public interface IEntityRepository<T> where T : class, IEntity,new() //T tipinin IEntity referans stiplerinde biri olabilir şartı kotduk
    {    //new() ile veirlen tipin new'lenebilecek bir tür vermemiz gerekiyor
        //böylece IEntity yazamamızı önledik-->İnterface olduğu için newlenemez.!
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T Get(Expression<Func<T, bool>> filter);//linq kullanarak filtreleme yapacağız
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        
    }
}
