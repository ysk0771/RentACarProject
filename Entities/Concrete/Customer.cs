using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Customer:User,IEntity
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
