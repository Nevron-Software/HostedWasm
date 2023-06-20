using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostedWasm.Server.Model
{
    [Table("Continent", Schema = "dbo")]
    public class Continent : IdRecord
    {
        [Required]
        public string Name { get; set; }
    }
}
