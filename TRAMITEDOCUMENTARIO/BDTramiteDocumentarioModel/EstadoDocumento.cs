using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("estado_documento", Schema = "documento")]
public partial class EstadoDocumento
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("descripcion")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("id_estado")]
    public bool? IdEstado { get; set; }

    [InverseProperty("EstadoNavigation")]
    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
