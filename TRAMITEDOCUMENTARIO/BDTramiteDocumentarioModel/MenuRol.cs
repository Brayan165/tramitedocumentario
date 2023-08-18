using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("menu_rol", Schema = "acceso")]
public partial class MenuRol
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("id_rol")]
    public short IdRol { get; set; }

    [Column("id_menu")]
    public short IdMenu { get; set; }

    [Column("id_status")]
    public bool IdStatus { get; set; }

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

    [ForeignKey("IdMenu")]
    [InverseProperty("MenuRols")]
    public virtual Menu IdMenuNavigation { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("MenuRols")]
    public virtual Rol IdRolNavigation { get; set; } = null!;
}
