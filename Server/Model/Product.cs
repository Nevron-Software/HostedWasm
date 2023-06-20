using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostedWasm.Server.Model
{
    [Table("Product", Schema = "dbo")]
    public class Product : IdRecord
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? ProductionCost { get; set; }
    }
}
