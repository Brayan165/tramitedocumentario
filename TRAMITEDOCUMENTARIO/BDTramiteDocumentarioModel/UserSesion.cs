using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("user_sesion", Schema = "log")]
public partial class UserSesion
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_user")]
    public int IdUser { get; set; }

    [Column("ip")]
    public string? Ip { get; set; }

    [Column("browser")]
    public string? Browser { get; set; }

    [Column("token")]
    public string? Token { get; set; }

    [Column("token_refresh")]
    public string? TokenRefresh { get; set; }

    [Column("fecha_crea")]
    [Precision(6)]
    public DateTime FechaCrea { get; set; }

    [Column("fecha_actualiza")]
    [Precision(6)]
    public DateTime FechaActualiza { get; set; }

    [ForeignKey("IdUser")]
    [InverseProperty("UserSesions")]
    public virtual Usuario IdUserNavigation { get; set; } = null!;
}
