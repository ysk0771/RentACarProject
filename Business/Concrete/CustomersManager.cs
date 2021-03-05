using Business.Abstract;
using Core.Utilities.Results;
using DataAccesses.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomersManager : ICustomersService
    {
        ICustomersDal _customerDal;
        public CustomersManager(ICustomersDal customers)
        {
            _customerDal = customers;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessesResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessesResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessesDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessesResult();
        }
    }
}
