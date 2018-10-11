using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("RegSesionError", Schema = "Bitacora")]
    public partial class RegSesionError
    {
        [Key]
        public int IdRegSesionErr { get; set; }
        public int IdUsuario { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaSesionErr { get; set; }
        public byte CantIntentos { get; set; }
    }
}
