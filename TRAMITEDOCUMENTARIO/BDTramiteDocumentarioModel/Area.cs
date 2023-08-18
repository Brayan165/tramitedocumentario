using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("area", Schema = "organizacion")]
public partial class Area
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("codigo")]
    [StringLength(20)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Required]
    [Column("id_estado")]
    public bool? IdEstado { get; set; }

    [InverseProperty("IdAreaNavigation")]
    public virtual ICollection<Colaborador> Colaboradors { get; set; } = new List<Colaborador>();

    [InverseProperty("IdAreaNavigation")]
    public virtual ICollection<DocumentoDerivacione> DocumentoDerivaciones { get; set; } = new List<DocumentoDerivacione>();

    [InverseProperty("IdAreaAsigandoNavigation")]
    public virtual ICollection<Documento> DocumentoIdAreaAsigandoNavigations { get; set; } = new List<Documento>();

    [InverseProperty("IdAreaOrigenNavigation")]
    public virtual ICollection<Documento> DocumentoIdAreaOrigenNavigations { get; set; } = new List<Documento>();
}
