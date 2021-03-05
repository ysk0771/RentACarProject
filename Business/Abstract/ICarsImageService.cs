using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarsImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Add(IFormFile image,CarImage carsImages);
        IResult Update(IFormFile image,CarImage carsimage);
        IResult Delete(CarImage image);
    }
}
