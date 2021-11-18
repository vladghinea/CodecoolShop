using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_Shop.SqlTables
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int DeliveryInfoId { get; set; }

        public virtual User User { get; set; }

        public virtual DeliveryInfo DeliveryInfo { get; set; }

        public virtual IEnumerable<OrderItem> Items { get; set; }
    }
}
