using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Keyless]
public partial class VUsuario
{
    [Column("id")]
    public int Id { get; set; }

    [Column("id_persona")]
    public int IdPersona { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string? Username { get; set; }

    [Column("password")]
    public string? Password { get; set; }

    [Column("change_password")]
    public bool? ChangePassword { get; set; }

    [Column("email")]
    [StringLength(80)]
    public string? Email { get; set; }

    [Column("id_rol")]
    public short IdRol { get; set; }

    [Column("identificador_celular")]
    [StringLength(50)]
    [Unicode(false)]
    public string? IdentificadorCelular { get; set; }

    [Column("id_estado")]
    public bool IdEstado { get; set; }

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

    [Column("nro_documento")]
    [StringLength(20)]
    [Unicode(false)]
    public string? NroDocumento { get; set; }

    [Column("nombre_completo")]
    [StringLength(180)]
    [Unicode(false)]
    public string? NombreCompleto { get; set; }

    [Column("celular")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Celular { get; set; }

    [Column("rolCodigo")]
    [StringLength(5)]
    [Unicode(false)]
    public string? RolCodigo { get; set; }

    [Column("rolDescripcion")]
    [StringLength(255)]
    public string? RolDescripcion { get; set; }
}
