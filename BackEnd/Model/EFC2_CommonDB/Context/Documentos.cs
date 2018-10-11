using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Documentos", Schema = "Documento")]
    public partial class Documentos
    {
        [Key]
        public long IdDocumento { get; set; }
        [Required]
        [StringLength(250)]
        public string NombreDoc { get; set; }
        [Required]
        [StringLength(5)]
        public string ExtensionDoc { get; set; }
        [Required]
        [StringLength(350)]
        public string RutaRelativaDoc { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaDoc { get; set; }
    }
}
