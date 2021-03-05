using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class ColorDetailDTO:IDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
