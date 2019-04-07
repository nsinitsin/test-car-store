using System.Collections.Generic;

namespace CatSolutions.EFEntity.Models
{
    public class User
    {
        public User()
        {
            UserCars = new List<UserCar>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public ICollection<UserCar> UserCars { get; set; }

        
    }
}