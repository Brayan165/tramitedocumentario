using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("rol", Schema = "acceso")]
public partial class Rol
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("codigo")]
    [StringLength(5)]
    [Unicode(false)]
    public string? Codigo { get; set; }

    [Column("descripcion")]
    [StringLength(255)]
    public string? Descripcion { get; set; }

    [Column("funcion")]
    public string? Funcion { get; set; }

    [Required]
    [Column("id_estado")]
    public bool? IdEstado { get; set; }

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
