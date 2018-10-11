using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC2_CommonDB.Context
{
    [Table("Personas", Schema = "Persona")]
    public partial class Personas
    {
        public Personas()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        [Key]
        public long IdPersona { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido2 { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaNacimiento { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaRegistroPer { get; set; }
        public int IdPais { get; set; }
        public int IdPaisNacimiento { get; set; }
        public byte IdProvincia { get; set; }
        public int IdCanton { get; set; }
        [StringLength(300)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(50)]
        public string Identificacion { get; set; }
        [Required]
        [StringLength(1)]
        public string TipoIdentificacion { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(1)]
        public string Genero { get; set; }
        [Required]
        [StringLength(1)]
        public string EstadoCivil { get; set; }

        [ForeignKey("IdCanton")]
        [InverseProperty("Personas")]
        public Cantones IdCantonNavigation { get; set; }
        [ForeignKey("IdPaisNacimiento")]
        [InverseProperty("PersonasIdPaisNacimientoNavigation")]
        public Paises IdPaisNacimientoNavigation { get; set; }
        [ForeignKey("IdPais")]
        [InverseProperty("PersonasIdPaisNavigation")]
        public Paises IdPaisNavigation { get; set; }
        [ForeignKey("IdProvincia")]
        [InverseProperty("Personas")]
        public Provincias IdProvinciaNavigation { get; set; }
        [InverseProperty("IdPersonaNavigation")]
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
