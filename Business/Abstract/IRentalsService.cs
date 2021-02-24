using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult<List<RentalsDetailDTO>> GetRentalsDetails();
        IResult Add(Rentals rentals);
        IResult Delete(Rentals rental);
        IResult Update(Rentals rental);
    }
}
