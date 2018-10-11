using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("UsuariosRoles", Schema = "Seguridad")]
    public partial class UsuariosRoles
    {
        [Key]
        public long IdUsuarioRol { get; set; }
        public long IdUsuario { get; set; }
        public short IdRol { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaAsigna { get; set; }

        [ForeignKey("IdRol")]
        [InverseProperty("UsuariosRoles")]
        public Roles IdRolNavigation { get; set; }
        [ForeignKey("IdUsuario")]
        [InverseProperty("UsuariosRoles")]
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
