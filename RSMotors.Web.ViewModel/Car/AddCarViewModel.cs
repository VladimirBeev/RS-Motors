using System.ComponentModel.DataAnnotations;

using static Common.EntityConstraints.CarConstraints;

namespace RSMotors.Web.ViewModel.Car
{
    public class AddCarViewModel
    {

        [Required]
        [StringLength(ManufacturerMaxLength)]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(YearMaxLength)]
        public string Year { get; set; } = null!;

        [Required]
        [StringLength(VinMaxLength)]
        public string Vin { get; set; } = null!;

        [Required]
        [StringLength(RegistrationPlateMaxLength)]
        public string RegistrationPlate { get; set; } = null!;

        public string? Details { get; set; }

        public Guid CustomerId { get; set; }

    }
}
