using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class ColorDetailDTO:IDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
