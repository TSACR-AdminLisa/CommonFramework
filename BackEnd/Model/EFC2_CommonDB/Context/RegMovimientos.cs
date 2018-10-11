using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("RegMovimientos", Schema = "Bitacora")]
    public partial class RegMovimientos
    {
        [Key]
        public long IdRegMovimiento { get; set; }
        public long IdUsuario { get; set; }
        public short IdModulo { get; set; }
        [Required]
        [StringLength(5)]
        public string TipoMovimiento { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreTabla { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreLlavePrimaria { get; set; }
        public long ValorLlavePrimaria { get; set; }
        [Required]
        [StringLength(200)]
        public string Detalle { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey("IdModulo")]
        [InverseProperty("RegMovimientos")]
        public Modulos IdModuloNavigation { get; set; }
    }
}
