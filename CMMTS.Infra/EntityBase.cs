using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMMTS.Infra
{
    public class EntityBase<T> where T : struct
    {
        [Key]
        [Column("Codigo")]
        public T Codigo { get; set; }
    }
}
