using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Permisos", Schema = "Seguridad")]
    public partial class Permisos
    {
        public Permisos()
        {
            PermisosModulos = new HashSet<PermisosModulos>();
        }

        [Key]
        public short IdPermiso { get; set; }
        [Required]
        [StringLength(3)]
        public string CodigoPerm { get; set; }
        [Required]
        [StringLength(100)]
        public string NombrePerm { get; set; }
        [Required]
        [StringLength(250)]
        public string DescripPerm { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaPerm { get; set; }
        public bool InactivoPerm { get; set; }

        [InverseProperty("IdPermisoNavigation")]
        public ICollection<PermisosModulos> PermisosModulos { get; set; }
    }
}
