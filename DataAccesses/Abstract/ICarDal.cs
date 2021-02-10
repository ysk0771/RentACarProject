using Core.DataAccesses;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesses.Abstract
{
    public interface ICarDal : IEntityRepository<Cars>
    {
        List<CarDetailDTO> GetCarDetails();
    }
}
