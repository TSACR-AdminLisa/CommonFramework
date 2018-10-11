using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("TipoUsuario", Schema = "Parametros")]
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        [Key]
        public byte IdTipoUsuario { get; set; }
        [Required]
        [StringLength(4)]
        public string CodigoTipoU { get; set; }
        [Required]
        [Column("TipoUsuario")]
        [StringLength(50)]
        public string TipoUsuario1 { get; set; }
        [StringLength(50)]
        public string DescripcionTipoU { get; set; }
        public bool InactivoTipoU { get; set; }

        [InverseProperty("IdTipoUsuarioNavigation")]
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
