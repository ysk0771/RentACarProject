using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccesses.Abstract;
using Entities;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;
        IColorService _colorService;
        

        public CarManager(ICarDal carDal,IColorService colors)
        {
            _CarDal = carDal;
            _colorService = colors;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Cars car)
        {
            
            //bussiness codes--iş kuralları
            //eğerm mevcut renk sayısı 15'i geçerse ürün eklenemez
            IResult result = BusinessRules.Run(CheckIfCarCountOfColorCorrect(car.ColorId),
               CheckIfColorsLimitExceded());
            if (result != null)
            {
                return result;
            }

            _CarDal.Add(car);
            return new SuccessesResult(Messages.ProductAdded);



        }

        public IDataResult<List<Cars>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Cars>>(Messages.MaintenainceTime);
            }
            return new SuccessesDataResult<List<Cars>>(_CarDal.GetAll(), Messages.ProductListed);

        }

        public IDataResult<List<Cars>> GetAllByColorId(int id)
        {
            return new SuccessesDataResult<List<Cars>>(_CarDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Cars>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessesDataResult<List<Cars>>(_CarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<Cars> GetById(int id)
        {
            return new SuccessesDataResult<Cars>(_CarDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessesDataResult<List<CarDetailDTO>>(_CarDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Cars car)
        {
            _CarDal.Update(car);
            return new SuccessesResult();
        }

        private IResult CheckIfCarCountOfColorCorrect(int colorId)
        {
            var result = _CarDal.GetAll(p => p.ColorId == colorId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarsColorIdError);
            }
            return new SuccessesResult();
        }
        private IResult CheckIfColorsLimitExceded()
        {

            var result = _colorService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.ColorLimitExceded);
            }
            return new SuccessesResult();
        }
    }
}
