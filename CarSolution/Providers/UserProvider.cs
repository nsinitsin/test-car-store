using System;
using System.Collections.Generic;
using CarSolution.Models;
using CatSolutions.BL.Services;

namespace CarSolution.Providers
{
    public interface IUserProvider
    {
        IList<UserViewModel> GetAllUsers();

        DetailedUserViewModel GetUser(int id);
    }

    public class UserProvider : IUserProvider
    {
        private readonly IUserService userSerice;

        public UserProvider(IUserService userSerice)
        {
            this.userSerice = userSerice;
        }

        public IList<UserViewModel> GetAllUsers()
        {
            var users = userSerice.GetAll();

            var result = new List<UserViewModel>();

            if (users == null) return result; 
            foreach (var user in users)
            {
                result.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name
                });
            }

            return result;
        }

        public DetailedUserViewModel GetUser(int id)
        {
            var user = userSerice.GetUser(id);

            if (user == null) return null;

            var result = new DetailedUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };

            if (user.UserCars == null) return result;

            foreach (var car in user.UserCars)
            {
                if (car.Car == null) throw new NullReferenceException("Car must be included to the object");

                var resultCar = new DetailedCarViewModel
                {
                    Id = car.Car.Id,
                    Model = car.Car.Model,
                    Date = car.Car.Date,
                    PlateNumber = car.PlateNumber
                };

                if (car.Car.Manufacturer == null) throw new NullReferenceException("Manufacturer must be included to the object");

                resultCar.Manufacturer = new DetailedManufacturerViewModel
                    {

                        Id = car.Car.Manufacturer.Id,
                        Name = car.Car.Manufacturer.Name,
                        Country = car.Car.Manufacturer.Country

                    };
                result.Cars.Add(resultCar);
            }

            return result;
        }
    }
}