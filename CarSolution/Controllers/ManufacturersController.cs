using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarSolution.Models;
using CarSolution.Providers;
using CatSolutions.BL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarSolution.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerProvider dataProvider;

        public ManufacturersController(IManufacturerProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        // GET: api/v1/gb/users
        [HttpGet("api/v{version}/{lang}/manufacturers")]
        public IEnumerable<ManufacturerViewModel> Get([Required]double version, [Required]string lang)
        {
            try
            {
                return dataProvider.GetManufacturers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ManufacturerViewModel>();
            }
        }
    }
}
