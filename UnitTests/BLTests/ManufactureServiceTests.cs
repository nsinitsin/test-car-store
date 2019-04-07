using System.Collections.Generic;
using System.Threading.Tasks;
using CarSolution.EF7;
using CatSolutions.BL.Services;
using CatSolutions.EFEntity.Models;
using Xunit;
using Moq;

namespace BLTests
{
    public class ManufactureServiceTests
    {
        public ManufactureServiceTests()
        {
            
        }

        [Fact]
        public void GetAllData_EmptyManufactures_0()
        {
            var result = new List<Manufacturer>
            {
                new Manufacturer
                {
                    Id = 1,
                    Country = "1",
                    Name = "1n"
                },
                new Manufacturer
                {
                    Id = 2,
                    Country = "2",
                    Name = "2n"
                }
            };

            var mock = new Mock<IAsyncRepository>();
            mock.Setup(s => s.GetAll<Manufacturer>())
                .Returns<string>(_ =>
                {
                    return result;
                });
            var repository = mock.Object;

            var service = new ManufacturerService(repository);
            var allManufacturers = service.GetAllManufacturers();
            Assert.Equal(result.Count, allManufacturers.Count);
        }
    
    }
}