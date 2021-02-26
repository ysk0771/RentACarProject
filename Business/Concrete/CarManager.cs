using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
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

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Cars car)
        {
            //bussiness codes--iş kuralları
            //validation--doğrulma--

            

            _CarDal.Add(car);

            return new SuccessesResult(Messages.ProductAdded);
        }

        public IDataResult<List<Cars>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 3)
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

    }
}
