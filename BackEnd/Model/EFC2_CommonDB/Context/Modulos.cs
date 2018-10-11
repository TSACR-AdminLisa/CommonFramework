using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Modulos", Schema = "Seguridad")]
    public partial class Modulos
    {
        public Modulos()
        {
            InverseIdModuloPadreNavigation = new HashSet<Modulos>();
            PermisosModulos = new HashSet<PermisosModulos>();
            RegMovimientos = new HashSet<RegMovimientos>();
        }

        [Key]
        public short IdModulo { get; set; }
        [Required]
        [StringLength(100)]
        public string NombreMod { get; set; }
        [Required]
        [StringLength(3)]
        public string CodigoMod { get; set; }
        public short IdModuloPadre { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaMod { get; set; }
        public short Nivel { get; set; }
        public bool InactivoMod { get; set; }

        [ForeignKey("IdModuloPadre")]
        [InverseProperty("InverseIdModuloPadreNavigation")]
        public Modulos IdModuloPadreNavigation { get; set; }
        [InverseProperty("IdModuloPadreNavigation")]
        public ICollection<Modulos> InverseIdModuloPadreNavigation { get; set; }
        [InverseProperty("IdModuloNavigation")]
        public ICollection<PermisosModulos> PermisosModulos { get; set; }
        [InverseProperty("IdModuloNavigation")]
        public ICollection<RegMovimientos> RegMovimientos { get; set; }
    }
}
