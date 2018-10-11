using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Usuarios", Schema = "Seguridad")]
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuariosRoles = new HashSet<UsuariosRoles>();
        }

        [Key]
        public long IdUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }
        [StringLength(100)]
        public string Contrasenia { get; set; }
        public byte IdTipoUsuario { get; set; }
        public bool EsTemporal { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaUsuario { get; set; }
        public bool InactivoUsu { get; set; }
        public long IdPersona { get; set; }

        [ForeignKey("IdPersona")]
        [InverseProperty("Usuarios")]
        public Personas IdPersonaNavigation { get; set; }
        [ForeignKey("IdTipoUsuario")]
        [InverseProperty("Usuarios")]
        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}
