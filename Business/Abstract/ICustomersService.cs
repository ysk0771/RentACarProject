﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICustomersService
    {
        public IResult Add(Customer customer);
        public IResult Delete(Customer customer);
        public IResult Update(Customer customer);
        public IDataResult<List<Customer>> GetAll();
    }
}
