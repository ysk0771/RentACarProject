using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccesses.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _usersDal;
        public UserManager(IUserDal users)
        {
            _usersDal = users;
        }

        public IResult Add(User user)
        {
            _usersDal.Add(user);
            return new SuccessesResult();
        }

        public IResult Update(User user)
        {
            _usersDal.Update(user);
            return new SuccessesResult();
        }

        public IResult Delete(User user)
        {
            _usersDal.Delete(user);
            return new SuccessesResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessesDataResult<List<User>>(_usersDal.GetAll());
        }

        public User GetByMail(string email)
        {
            
            return _usersDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _usersDal.GetClaims(user);
        }
    }
}
