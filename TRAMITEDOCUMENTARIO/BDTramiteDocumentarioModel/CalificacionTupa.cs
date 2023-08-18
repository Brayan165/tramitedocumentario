using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("calificacion_tupa", Schema = "documento")]
public partial class CalificacionTupa
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("descripcion")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("id_estado")]
    public bool? IdEstado { get; set; }
}
