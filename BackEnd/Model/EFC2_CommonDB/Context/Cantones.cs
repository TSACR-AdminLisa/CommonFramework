using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Cantones", Schema = "Parametros")]
    public partial class Cantones
    {
        public Cantones()
        {
            Personas = new HashSet<Personas>();
        }

        [Key]
        public int IdCanton { get; set; }
        [Required]
        [StringLength(100)]
        public string Canton { get; set; }
        public byte IdProvincia { get; set; }

        [ForeignKey("IdProvincia")]
        [InverseProperty("Cantones")]
        public Provincias IdProvinciaNavigation { get; set; }
        [InverseProperty("IdCantonNavigation")]
        public ICollection<Personas> Personas { get; set; }
    }
}
