using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Errores", Schema = "Log")]
    public partial class Errores
    {
        [Key]
        public long IdError { get; set; }
        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(200)]
        public string Detalle { get; set; }
        [Required]
        [StringLength(60)]
        public string Archivo { get; set; }
        [Required]
        [StringLength(50)]
        public string Metodo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
    }
}
