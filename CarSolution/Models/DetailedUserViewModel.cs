using System;
using System.Collections.Generic;

namespace CarSolution.Models
{
    public class DetailedUserViewModel
    {
        public DetailedUserViewModel()
        {
            Cars = new List<DetailedCarViewModel>();
        }

        public long Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public IList<DetailedCarViewModel> Cars { get; set; }
    }

    public class DetailedCarViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public DateTime Date { get; set; }

        public int PlateNumber { get; set; }

        public DetailedManufacturerViewModel Manufacturer { get; set; }
    }

    public class DetailedManufacturerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }
    }
}