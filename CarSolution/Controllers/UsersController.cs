using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarSolution.Models;
using CarSolution.Providers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarSolution.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserProvider dataProvider;

        public UsersController(IUserProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        // GET: api/v1/gb/users
        [HttpGet("api/v{version}/{lang}/users")]
        public IEnumerable<UserViewModel> Get([Required]double version, [Required]string lang)
        {
            try
            {
                return dataProvider.GetAllUsers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<UserViewModel>();
            }
            
        }

        // GET api/v1/gb/users/5
        [HttpGet("api/v{version}/{lang}/users/{id}")]
        public DetailedUserViewModel Get([Required]double version, [Required]string lang, int id)
        {
            try
            {
                return dataProvider.GetUser(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DetailedUserViewModel();
            }
            
        }
    }
}
