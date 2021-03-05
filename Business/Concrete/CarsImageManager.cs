using Business.Abstract;
using Core.Utilities.Results;
using DataAccesses.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarsImageManager : ICarsImageService
    {
        ICarsImagesDal _carsImageDal;
        public CarsImageManager(ICarsImagesDal ımagedal)
        {
            _carsImageDal = ımagedal;
        }
        public IResult Add(IFormFile image, CarImage carsImages)
        {
           // carsImages.CarImages = new FileHelper().(image);
            carsImages.Date = DateTime.Now;
            _carsImageDal.Add(carsImages);
            return new SuccessesResult();
            
        }

       

        public IResult Delete(CarImage image)
        {
            _carsImageDal.Delete(image);
            return new SuccessesResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessesDataResult<List<CarImage>>(_carsImageDal.GetAll());
        }

        public IResult Update(IFormFile image, CarImage carsimage)
        {
            _carsImageDal.Update(carsimage);
            return new SuccessesResult();
        }

        
    }
}
