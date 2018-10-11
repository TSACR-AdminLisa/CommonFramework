using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("PermisosModulos", Schema = "Seguridad")]
    public partial class PermisosModulos
    {
        public short IdModulo { get; set; }
        public short IdPermiso { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaPermiMod { get; set; }

        [ForeignKey("IdModulo")]
        [InverseProperty("PermisosModulos")]
        public Modulos IdModuloNavigation { get; set; }
        [ForeignKey("IdPermiso")]
        [InverseProperty("PermisosModulos")]
        public Permisos IdPermisoNavigation { get; set; }
    }
}
