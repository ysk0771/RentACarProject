using Business.Abstract;
using Core.Utilities.Results;
using DataAccesses.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colordal)
        {
            _colorDal = colordal;
        }
        public IResult Add(Colors color)
        {
            _colorDal.Add(color);
            return new SuccessesResult();
        }

        public IDataResult<List<Colors>> GetAll()
        {
            //businnes codess
            return new SuccessesDataResult<List<Colors>>(_colorDal.GetAll()) ;
        }

        public IResult Update(Colors color)
        {
            _colorDal.Update(color);
            return new SuccessesResult();
        }
    }
}
