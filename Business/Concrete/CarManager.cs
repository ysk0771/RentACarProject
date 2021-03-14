using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transection;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccesses.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;
        IColorService _colorService;


        public CarManager(ICarDal carDal, IColorService colors)
        {
            _CarDal = carDal;
            _colorService = colors;
        }

        //claim
        [SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
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

        [TransactionScopeAspect]//Burdaki senaryoda bir işlemin yapamamıs durumunda yapılan işlemleri geri alıp hiç olmamış gibi kalıyor.
        //örnek olarak para gönderdik ancak sistem hata verdi parayı bizden çekti karşıya gönderemedi bunu önlemiş olan sistem bu vb. sistemlerdir
        public IResult AddTransectionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception();
            }

            Add(car);

            return null;
        }

        [CacheAspect]//Çok kullanılar durumları Ön Belleğe alıp oradan çağırırız bu aspect bu işe yarar.
        [PerformanceAspect(5)]//Bu metodun çalışması 5 saniyeyi geçerse beni uyar.
        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenainceTime);
            }
            return new SuccessesDataResult<List<Car>>(_CarDal.GetAll(), Messages.ProductListed);

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessesDataResult<List<Car>>(_CarDal.GetAll(p => p.ColorId == id));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessesDataResult<List<Car>>(_CarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessesDataResult<Car>(_CarDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessesDataResult<List<CarDetailDTO>>(_CarDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
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
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.ColorLimitExceded);
            }
            return new SuccessesResult();
        }
    }
}
