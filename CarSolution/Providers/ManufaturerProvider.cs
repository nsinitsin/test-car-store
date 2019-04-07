using System.Collections.Generic;
using CarSolution.Models;
using CatSolutions.BL.Services;

namespace CarSolution.Providers
{
    public interface IManufacturerProvider
    {
        IList<ManufacturerViewModel> GetManufacturers();
    }

    public class ManufacturerProvider : IManufacturerProvider
    {
        private readonly IManufacturerService service;

        public ManufacturerProvider(IManufacturerService service)
        {
            this.service = service;
        }
        public IList<ManufacturerViewModel> GetManufacturers()
        {
            var allManufacturers = service.GetAllManufacturers();

            var result = new List<ManufacturerViewModel>();

            if (allManufacturers == null) return result;
            foreach (var allManufacturer in allManufacturers)
            {
                var resultCars = new List<CarViewModel>();

                if (allManufacturer.Cars != null)
                {
                    foreach (var allManufacturerCar in allManufacturer.Cars)
                    {
                        var resultCar = new CarViewModel
                        {
                            Date = allManufacturerCar.Date,
                            Id = allManufacturerCar.Id,
                            Model = allManufacturerCar.Model
                        };
                        resultCars.Add(resultCar);
                    }
                }
                var resultManufacture = new ManufacturerViewModel
                {
                    Id = allManufacturer.Id,
                    Country = allManufacturer.Country,
                    Name = allManufacturer.Name,
                    Cars = resultCars
                };
                result.Add(resultManufacture);
            }

            return result;
        }
    }
}