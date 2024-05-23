using CMMTS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMMTS.Domain.Entities
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoAcesso TipoAcesso { get; set; }
        public bool Status {  get; set; }
    }
}
