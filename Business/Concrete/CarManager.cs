using Business.Abstract;
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

        public List<Cars> GetAll()
        {
            //iş kodları
            return _CarDal.GetAll();

        }

        public List<Cars> GetAllByColorId(int id)
        {
            return _CarDal.GetAll(p=>p.ColorId==id);
        }

        public List<Cars> GetByDailyPrice(decimal min, decimal max)
        {
            return _CarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            return _CarDal.GetCarDetails();
        }
    }
}
