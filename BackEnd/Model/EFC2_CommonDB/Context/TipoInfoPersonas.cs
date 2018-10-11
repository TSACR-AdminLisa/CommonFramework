using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("TipoInfoPersonas", Schema = "Parametros")]
    public partial class TipoInfoPersonas
    {
        [Key]
        public short IdTipoInfoPersona { get; set; }
        [Required]
        [StringLength(75)]
        public string TipoInfoPersona { get; set; }
        [Required]
        [StringLength(50)]
        public string TipoDato { get; set; }
        public bool EsObligatorio { get; set; }
        public bool EsPrivado { get; set; }
    }
}
