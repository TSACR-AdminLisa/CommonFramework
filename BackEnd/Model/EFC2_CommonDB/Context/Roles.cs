using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Roles", Schema = "Seguridad")]
    public partial class Roles
    {
        public Roles()
        {
            UsuariosRoles = new HashSet<UsuariosRoles>();
        }

        [Key]
        public short IdRol { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreRol { get; set; }
        [StringLength(250)]
        public string DescripcionRol { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaRol { get; set; }
        public bool InactivoRol { get; set; }

        [InverseProperty("IdRolNavigation")]
        public ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}
