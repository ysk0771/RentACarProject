using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface ICarService
    {
        List<Cars> GetAll();
        List<Cars> GetAllByColorId(int id);
        List<Cars> GetByDailyPrice(decimal min, decimal max);
    }
}
