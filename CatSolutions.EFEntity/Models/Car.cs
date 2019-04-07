using System;
using System.Collections.Generic;

namespace CatSolutions.EFEntity.Models
{
    public class Car
    {
        public Car()
        {
            UserCars = new List<UserCar>();
        }
        public int Id { get; set; }

        public string Model { get; set; }

        public DateTime Date { get; set; }

        public ICollection<UserCar> UserCars { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public int ManufacturerId { get; set; }
    }
}