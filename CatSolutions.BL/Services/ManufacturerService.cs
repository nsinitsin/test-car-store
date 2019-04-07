using System.Collections.Generic;
using System.Linq;
using CarSolution.EF7;
using CatSolutions.EFEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace CatSolutions.BL.Services
{
    public interface IManufacturerService
    {
        IList<Manufacturer> GetAllManufacturers();
    }

    public class ManufacturerService : IManufacturerService
    {
        private readonly IAsyncRepository repository;

        public ManufacturerService(IAsyncRepository repository)
        {
            this.repository = repository;
        }

        public IList<Manufacturer> GetAllManufacturers()
        {
            return repository.GetQuery<Manufacturer>().Include(i=>i.Cars).ToList(); 
        }
    }

    
}