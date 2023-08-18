using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("colaborador", Schema = "rrhh")]
[Index("IdPersona", Name = "UQ__colabora__228148B1CE93F3E6", IsUnique = true)]
public partial class Colaborador
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("id_cargo")]
    public int IdCargo { get; set; }

    [Column("id_area")]
    public int IdArea { get; set; }

    [Required]
    [Column("id_estado")]
    public bool? IdEstado { get; set; }

    [Column("usuario_crea")]
    public int UsuarioCrea { get; set; }

    [Column("usuario_actualiza")]
    public int UsuarioActualiza { get; set; }

    [Column("fecha_crea")]
    [Precision(6)]
    public DateTime FechaCrea { get; set; }

    [Column("fecha_actualiza")]
    [Precision(6)]
    public DateTime FechaActualiza { get; set; }

    [ForeignKey("IdArea")]
    [InverseProperty("Colaboradors")]
    public virtual Area IdAreaNavigation { get; set; } = null!;

    [ForeignKey("IdCargo")]
    [InverseProperty("Colaboradors")]
    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    [ForeignKey("IdPersona")]
    [InverseProperty("Colaborador")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
