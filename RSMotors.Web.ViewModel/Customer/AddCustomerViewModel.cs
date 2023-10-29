using System.ComponentModel.DataAnnotations;

using static Common.EntityConstraints.CustomerConstraints;

namespace RSMotors.Web.ViewModel.Customer
{
    public class AddCustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

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
    }
}
