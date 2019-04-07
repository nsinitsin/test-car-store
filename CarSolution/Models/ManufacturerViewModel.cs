using System;
using System.Collections.Generic;

namespace CarSolution.Models
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public IList<CarViewModel> Cars { get; set; }
    }

    public class CarViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public DateTime Date { get; set; }
    }
}