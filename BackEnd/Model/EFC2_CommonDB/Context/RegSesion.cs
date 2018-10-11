using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("RegSesion", Schema = "Bitacora")]
    public partial class RegSesion
    {
        [Key]
        public int IdRegSesion { get; set; }
        public int IdUsuario { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaIniSesion { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaFinSesion { get; set; }
        public double DuracionSesion { get; set; }
    }
}
