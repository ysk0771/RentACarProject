using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface ICarService
    {
        IDataResult<List<Cars>> GetAll();
        IDataResult<List<Cars>> GetAllByColorId(int id);
        IDataResult<List<Cars>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDTO>> GetCarDetails();
        IResult Add(Cars car);
        IResult Update(Cars car);

        IDataResult<Cars> GetById(int id);
    }
}
