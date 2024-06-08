using CMMTS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMMTS.Domain.Entities
{
    [Table("HistoricoWaypoints")]
    public class HistoricoWaypoints
    {
        [Key]
        public string Codigo { get; set; }
        public string CodigoWaypoint { get; set; }
        public SituacaoEntrega Situacao { get; set; }
        public DateTime DtSituacao { get; set; }
        public DateTime DtInclusao { get; set; }
    }
}
