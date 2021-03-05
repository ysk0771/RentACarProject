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
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalsDetailDTO>> GetRentalsDetails();
        IResult Add(Rental rentals);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
    }
}
