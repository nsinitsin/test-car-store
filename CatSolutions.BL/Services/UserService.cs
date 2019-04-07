using System.Collections.Generic;
using System.Linq;
using CarSolution.EF7;
using CatSolutions.EFEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace CatSolutions.BL.Services
{
    public interface IUserService
    {
        IList<User> GetAll();
        User GetUser(int id);
    }

    public class UserService : IUserService
    {
        private readonly IAsyncRepository repository;

        public UserService(IAsyncRepository repository)
        {
            this.repository = repository;
        }

        public IList<User> GetAll()
        {
            return repository.GetAll<User>().ToList();
        }

        public User GetUser(int id)
        {
            var user = repository.GetQuery<User>(u=>u.Id == id).Include(s=>s.UserCars).FirstOrDefault();

            if (user.UserCars == null) return user;

            var carIds = user.UserCars.Select(s => s.CarId);
            var cars = repository.GetQuery<Car>(s => carIds.Contains(s.Id)).Include(f => f.Manufacturer);
            foreach (var car in user.UserCars)
            {
                car.Car = cars.First(s => s.Id == car.CarId);
            }
            return user;
        }
    }
}