using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_Shop.SqlTables
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal DefaultPrice { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Currency { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        public int SuplierId { get; set; }

        [Required]
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [Required]
        public virtual ProductCategory Category { get; set; }

        [Required]
        public virtual Suplier Suplier { get; set; }
    }
}
