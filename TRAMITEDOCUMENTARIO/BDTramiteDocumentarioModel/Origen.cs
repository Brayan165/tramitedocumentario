using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("origen", Schema = "documento")]
public partial class Origen
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("descripcion")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("id_estado")]
    public bool? IdEstado { get; set; }

    [InverseProperty("OrigenNavigation")]
    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
