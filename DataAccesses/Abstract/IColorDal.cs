using Core.DataAccesses;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccesses.Abstract
{
    public interface IColorDal:IEntityRepository<Color>
    {
        List<ColorDetailDTO> GetColorDetails();
    }
}
