using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMMTS.Domain.Entities
{
    [Table("distribution_centers")]
    public class distribution_centers
    {
        [Key]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string PlaceIdCentro { get; set; }
    }
}
