using Core.DataAccesses;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesses.Abstract
{
    public interface IRentalsDal : IEntityRepository<Rentals>
    {
        
        List<RentalsDetailDTO> GetRentalsDetails();
    }
}
