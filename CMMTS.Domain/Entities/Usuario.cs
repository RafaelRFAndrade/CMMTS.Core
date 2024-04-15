using System.ComponentModel.DataAnnotations.Schema;

namespace CMMTS.Domain.Entities
{
    [Table("dbo.Usuarios")]
    public class Usuario 
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }

        public static explicit operator List<object>(Usuario v)
        {
            throw new NotImplementedException();
        }
    }
}
