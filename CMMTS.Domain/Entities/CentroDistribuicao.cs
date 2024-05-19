﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMMTS.Domain.Entities
{
    [Table("distribution_centers")]
    public class CentroDistribuicao
    {
        [Key]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
