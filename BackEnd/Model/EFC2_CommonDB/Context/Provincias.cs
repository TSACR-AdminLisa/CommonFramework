using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Provincias", Schema = "Parametros")]
    public partial class Provincias
    {
        public Provincias()
        {
            Cantones = new HashSet<Cantones>();
            Personas = new HashSet<Personas>();
        }

        [Key]
        public byte IdProvincia { get; set; }
        [Required]
        [StringLength(100)]
        public string Provincia { get; set; }
        public int IdPais { get; set; }

        [ForeignKey("IdPais")]
        [InverseProperty("Provincias")]
        public Paises IdPaisNavigation { get; set; }
        [InverseProperty("IdProvinciaNavigation")]
        public ICollection<Cantones> Cantones { get; set; }
        [InverseProperty("IdProvinciaNavigation")]
        public ICollection<Personas> Personas { get; set; }
    }
}
