using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("menu", Schema = "acceso")]
public partial class Menu
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("icono")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Icono { get; set; }

    [Column("datatarget")]
    [StringLength(30)]
    public string? Datatarget { get; set; }

    [Column("url")]
    [StringLength(200)]
    public string? Url { get; set; }

    [Column("padre")]
    public int Padre { get; set; }

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

    [InverseProperty("IdMenuNavigation")]
    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();
}
