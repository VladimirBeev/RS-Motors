using System.ComponentModel.DataAnnotations;

using static Common.EntityConstraints.CarConstraints;

namespace RSMotors.Infrastructure.Models
{
    public class Car
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

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

        [Required]
        public Customer Customer { get; set; } = null!;

        
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();

        public ICollection<RepairPart> RepairParts { get; set; } = new List<RepairPart>();
    }
}
