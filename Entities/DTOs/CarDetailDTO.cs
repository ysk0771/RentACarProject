using Core;
using System;
using System.Collections.Generic;
using System.Text;

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
