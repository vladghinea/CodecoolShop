using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_Shop.SqlTables
{
    public class DeliveryInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string PhoneNumber { get; set; }

        public virtual User User { get; set; }

    }
}
