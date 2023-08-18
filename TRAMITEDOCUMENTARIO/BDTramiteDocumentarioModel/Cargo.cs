using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("cargo", Schema = "organizacion")]
public partial class Cargo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("codigo")]
    [StringLength(30)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    public string? Nombre { get; set; }

    [Required]
    [Column("id_estado")]
    public bool? IdEstado { get; set; }

    [InverseProperty("IdCargoNavigation")]
    public virtual ICollection<Colaborador> Colaboradors { get; set; } = new List<Colaborador>();
}
