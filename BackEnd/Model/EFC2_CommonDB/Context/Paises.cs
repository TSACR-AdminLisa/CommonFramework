using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Paises", Schema = "Parametros")]
    public partial class Paises
    {
        public Paises()
        {
            PersonasIdPaisNacimientoNavigation = new HashSet<Personas>();
            PersonasIdPaisNavigation = new HashSet<Personas>();
            Provincias = new HashSet<Provincias>();
        }

        [Key]
        public int IdPais { get; set; }
        [Required]
        [StringLength(3)]
        public string CodigoPais { get; set; }
        [Required]
        [StringLength(100)]
        public string Pais { get; set; }
        [StringLength(4)]
        public string CodigoArea { get; set; }

        [InverseProperty("IdPaisNacimientoNavigation")]
        public ICollection<Personas> PersonasIdPaisNacimientoNavigation { get; set; }
        [InverseProperty("IdPaisNavigation")]
        public ICollection<Personas> PersonasIdPaisNavigation { get; set; }
        [InverseProperty("IdPaisNavigation")]
        public ICollection<Provincias> Provincias { get; set; }
    }
}
