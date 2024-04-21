using CMMTS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMMTS.Domain.Entities
{
    [Table("dbo.Usuarios")]
    public class Usuario 
    {
        [Key]
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoAcesso TipoAcesso { get; set; }
    }
}
