using System.ComponentModel.DataAnnotations;

using static Common.EntityConstraints.PaymentConstraints;

namespace RSMotors.Infrastructure.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(CustomerNameMaxLength)]
        public string CustomerName { get; set; } = null!;

        [Required]
        [StringLength(PaymentMethodMaxLength)]
        public string PaymentMethod { get; set; } = null!;

        public decimal Amount { get; set; }

        [Required]
        public DateTime DateOfPayment { get; set; }

        [Required]
        public bool IsActive { get; set; }


        public Guid CarId { get; set; }

        [Required]
        public Car Car { get; set; } = null!;

        public ICollection<RepairPart> RepairParts { get; set; } = new List<RepairPart>();
    }
}
