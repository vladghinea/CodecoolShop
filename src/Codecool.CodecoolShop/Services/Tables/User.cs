using System.ComponentModel.DataAnnotations.Schema;

namespace Codecool.CodecoolShop.Services.Tables
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Password { get; set; }
    }
}
