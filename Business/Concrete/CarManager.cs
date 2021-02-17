﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccesses.Abstract;
using Entities;
using Entities.DTOs;
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

        public IResult Add(Cars car)
        {
            //bussiness codes
            if (car.Descriptions.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _CarDal.Add(car);

            return new SuccessesResult(Messages.ProductAdded);
        }

        public IDataResult<List<Cars>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour==3)
            {
              return new ErrorDataResult<List<Cars>>(Messages.MaintenainceTime);
            }
            return new SuccessesDataResult<List<Cars>>(_CarDal.GetAll(),Messages.ProductListed);

        }

        public IDataResult<List<Cars>> GetAllByColorId(int id)
        {
            return new SuccessesDataResult<List<Cars>>(_CarDal.GetAll(p=>p.ColorId==id));
        }

        public IDataResult<List<Cars>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessesDataResult<List<Cars>>(_CarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessesDataResult<List<CarDetailDTO>>(_CarDal.GetCarDetails());
        }
    }
}
