using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public  class CarDetailDTO:IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }

  
    }
}
