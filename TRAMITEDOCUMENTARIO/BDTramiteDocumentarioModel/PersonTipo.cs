using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("person_tipo", Schema = "persona")]
public partial class PersonTipo
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("descripcion")]
    [StringLength(25)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdPersonaTipoNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
