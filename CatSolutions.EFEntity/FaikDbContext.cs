using System.Collections.Generic;
using CatSolutions.EFEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace CatSolutions.EFEntity
{
    public class FaikDbContext
    {
        public static bool IsAdded { get; set; }

        public FaikDbContext()
        {
        }
        public CarSlnDbContext GetFaikDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarSlnDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            var context = new CarSlnDbContext(optionsBuilder.Options);
            if (IsAdded) return context;
            context.Cars.AddRange(GenerateFaikCarsObjects());
            context.Manufacturers.AddRange(GenerateFaikManufacturersObjects());
            context.Users.AddRange(GenerateFaikUsersObjects());
            context.UserCars.AddRange(GenerateFaikUserCarsObjects());
            context.SaveChanges();
            IsAdded = true;
            return context;
        }

        public IEnumerable<User> GenerateFaikUsersObjects()
        {
            List<User> result = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Email = "test@test.com",
                    Name = "John"
                },
                new User
                {
                    Id = 2,
                    Email = "test2@test.com",
                    Name = "Nick"
                },
                new User
                {
                    Id = 3,
                    Email = "test3@test.com",
                    Name = "Anna"
                }
            };



            return result;
        }

        public IEnumerable<UserCar> GenerateFaikUserCarsObjects()
        {
            List<UserCar> result = new List<UserCar>()
            {
                new UserCar
                {
                    PlateNumber = 1,
                    CarId = 1,
                    UserId = 1
                },
                new UserCar
                {
                    PlateNumber = 2,
                    CarId = 2,
                    UserId = 1
                },
                new UserCar
                {
                    PlateNumber = 3,
                    CarId = 1,
                    UserId = 2
                },
                new UserCar
                {
                    PlateNumber = 4,
                    CarId = 3,
                    UserId = 2
                },
            };



            return result;
        }

        public IEnumerable<Car> GenerateFaikCarsObjects()
        {
            List<Car> result = new List<Car>()
            {
                new Car
                {
                    Id = 1,
                    Date = new System.DateTime(2017,01,10),
                    Model = "Mazda 3",
                    ManufacturerId = 1
                },
                new Car
                {
                    Id = 2,
                    Date = new System.DateTime(2017,01,10),
                    Model = "Mazda 6",
                    ManufacturerId = 1
                },
                new Car
                {
                    Id = 3,
                    Date = new System.DateTime(2017,04,11),
                    Model = "BMW x3",
                    ManufacturerId = 2
                },
                new Car
                {
                    Id = 4,
                    Date = new System.DateTime(2017,04,11),
                    Model = "Audi A3",
                    ManufacturerId = 3
                }
                ,
                new Car
                {
                    Id = 5,
                    Date = new System.DateTime(2017,04,11),
                    Model = "Astra",
                    ManufacturerId = 4
                }
            };

            return result;
        }

        public IEnumerable<Manufacturer> GenerateFaikManufacturersObjects()
        {
            List<Manufacturer> result = new List<Manufacturer>()
            {
                new Manufacturer
                {
                    Id = 1,
                    Country = "Japan",
                    Name = "Mazda"
                },
                new Manufacturer
                {
                    Id = 2,
                    Country = "German",
                    Name = "BMW"
                },
                new Manufacturer
                {
                    Id = 3,
                    Country = "German",
                    Name = "Audi"
                },
                new Manufacturer
                {
                    Id = 4,
                    Country = "German",
                    Name = "Vauxhall"
                },
                new Manufacturer
                {
                    Id = 5,
                    Country = "Japan",
                    Name = "Toyota"
                }
            };

            return result;
        }
    }
}