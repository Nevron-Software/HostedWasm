using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostedWasm.Server.Model
{
    [Table("Order", Schema = "dbo")]
    public class Order : IdRecord
    {
        [Required]
        [ForeignKey("FK_Order_Customer")]
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("FK_Order_Product")]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
