using Core.DataAccesses;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccesses.Abstract
{
    public interface IRentalsDal : IEntityRepository<Rental>
    {
        
        List<RentalsDetailDTO> GetRentalsDetails();
    }
}
