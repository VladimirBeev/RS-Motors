using System.ComponentModel.DataAnnotations;

using static Common.EntityConstraints.RepairPartConstraints;

namespace RSMotors.Infrastructure.Models
{
    public class RepairPart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
