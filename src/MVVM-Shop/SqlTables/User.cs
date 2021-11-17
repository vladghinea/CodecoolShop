using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_Shop.SqlTables
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Password { get; set; }
    }
}
