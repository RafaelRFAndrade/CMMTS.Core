using CMMTS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMMTS.Domain.Entities
{
    [Table("routes")]
    public class routes
    {
        public string Codigo { get; set; }
        public string CodigoCentroDistribuicao { get; set; }
        public string WaypointsJson { get; set; }
        public TipoRota TipoRota { get; set; }
    }
}
