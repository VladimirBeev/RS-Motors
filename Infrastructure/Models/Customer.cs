using System.ComponentModel.DataAnnotations;

using static Common.EntityConstraints.CustomerConstraints;

namespace RSMotors.Infrastructure.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneMaxLength)]
        public string Phone { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
