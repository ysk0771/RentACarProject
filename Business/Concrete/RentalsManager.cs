using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccesses.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _RentalsDal;
        public RentalsManager(IRentalsDal customersDal)
        {
            _RentalsDal = customersDal;
        }

        public IResult Add(Rental rentals)
        {
            var result = GetRentalsDetails().Data.SingleOrDefault(p => p.CarId == rentals.CarId);
            if (result.ReturnDate != null)
            {
                _RentalsDal.Add(rentals);
                return new SuccessesResult(Messages.ProductAdded);
            }
            return new ErrorResult(Messages.ProductNameInvalid);
        }

        public IResult Delete(Rental rentals)
        {
          
                _RentalsDal.Delete(rentals);
                return new SuccessesResult(Messages.ProductDelete);
            
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessesDataResult<List<Rental>>(_RentalsDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<RentalsDetailDTO>> GetRentalsDetails()
        {
            return new SuccessesDataResult<List<RentalsDetailDTO>>(_RentalsDal.GetRentalsDetails(), Messages.ProductListed);
        }

        public IResult Update(Rental rentals)
        {
            _RentalsDal.Update(rentals);
            return new SuccessesResult(Messages.ProductUpdate);
        }
    }
}
