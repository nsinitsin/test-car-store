using System.Collections.Generic;

namespace CatSolutions.EFEntity.Models
{
    public class UserCar
    {
        public int PlateNumber { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }
    }
}