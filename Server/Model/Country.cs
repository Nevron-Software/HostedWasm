using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostedWasm.Server.Model
{
    [Table("Country", Schema = "dbo")]
    public class Country : IdRecord
    {
        [Required]
        [ForeignKey("FK_Country_Continent")]
        public int ContinentId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
