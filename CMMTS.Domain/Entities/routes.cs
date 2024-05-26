using CMMTS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMMTS.Domain.Entities
{
    [Table("routes")]
    public class routes
    {
        [Key]
        public string Codigo { get; set; }
        public string PlaceIdOrigem { get; set; }
        public string PlaceIdDestino { get; set; }
        public TipoRota TipoRota { get; set; }
    }
}
