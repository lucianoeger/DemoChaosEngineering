using System.ComponentModel.DataAnnotations;

namespace DemoChaosEngineeringCar.ViewModel
{
    public class AddUpdateCarViewModel
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 0.01, maximum: double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1970, 2022)]
        public int Year { get; set; }
    }
}
