using System.Collections.Generic;

namespace CatSolutions.EFEntity.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Cars = new List<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
