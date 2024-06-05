using EmlakPortali.Models;

namespace EmlakPortali.Dtos
{
    public class HouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
