using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("usuario", Schema = "acceso")]
public partial class Usuario
{
    [Key]
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

    [InverseProperty("IdUsuarioActualizaNavigation")]
    public virtual ICollection<Documento> DocumentoIdUsuarioActualizaNavigations { get; set; } = new List<Documento>();

    [InverseProperty("IdUsuarioRegistroNavigation")]
    public virtual ICollection<Documento> DocumentoIdUsuarioRegistroNavigations { get; set; } = new List<Documento>();

    [InverseProperty("UsuarioActualizaNavigation")]
    public virtual ICollection<Error> ErrorUsuarioActualizaNavigations { get; set; } = new List<Error>();

    [InverseProperty("UsuarioCreaNavigation")]
    public virtual ICollection<Error> ErrorUsuarioCreaNavigations { get; set; } = new List<Error>();

    [ForeignKey("IdPersona")]
    [InverseProperty("Usuarios")]
    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("Usuarios")]
    public virtual Rol IdRolNavigation { get; set; } = null!;

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<UserSesion> UserSesions { get; set; } = new List<UserSesion>();
}
