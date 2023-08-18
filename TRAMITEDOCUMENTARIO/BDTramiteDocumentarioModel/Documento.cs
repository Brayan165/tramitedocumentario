using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

[Table("documento", Schema = "documento")]
[Index("NroExpediente", Name = "documento_expediente")]
[Index("NroDocumento", Name = "documento_numero")]
public partial class Documento
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_tipo_documento")]
    public short IdTipoDocumento { get; set; }

    [Column("id_prioridad")]
    public short IdPrioridad { get; set; }

    [Column("id_forma_recepcion")]
    public short IdFormaRecepcion { get; set; }

    [Column("nro_documento")]
    public int? NroDocumento { get; set; }

    [Column("nro_expediente")]
    public int? NroExpediente { get; set; }

    [Column("fecha_registro", TypeName = "date")]
    public DateTime FechaRegistro { get; set; }

    [Column("hora_registro")]
    public TimeSpan HoraRegistro { get; set; }

    [Column("fecha_documento", TypeName = "date")]
    public DateTime FechaDocumento { get; set; }

    [Column("siglas_documento")]
    [StringLength(100)]
    [Unicode(false)]
    public string? SiglasDocumento { get; set; }

    [Column("snip")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Snip { get; set; }

    [Column("asunto")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Asunto { get; set; }

    [Column("origen")]
    public short Origen { get; set; }

    [Column("id_persona_origen")]
    public int? IdPersonaOrigen { get; set; }

    [Column("id_area_origen")]
    public int? IdAreaOrigen { get; set; }

    [Column("id_area_asigando")]
    public int? IdAreaAsigando { get; set; }

    [Column("id_persona_asignada")]
    public int? IdPersonaAsignada { get; set; }

    [Column("detalle")]
    [Unicode(false)]
    public string? Detalle { get; set; }

    [Column("firma")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Firma { get; set; }

    [Column("cargo")]
    [StringLength(150)]
    [Unicode(false)]
    public string? Cargo { get; set; }

    [Column("archivo")]
    [StringLength(300)]
    [Unicode(false)]
    public string? Archivo { get; set; }

    [Column("nro_folios")]
    public int? NroFolios { get; set; }

    [Column("dias_atencion")]
    public short? DiasAtencion { get; set; }

    [Column("estado")]
    public short Estado { get; set; }

    [Column("id_usuario_registro")]
    public int? IdUsuarioRegistro { get; set; }

    [Column("id_usuario_actualiza")]
    public int? IdUsuarioActualiza { get; set; }

    [Column("fecha_hora_actualizacion", TypeName = "datetime")]
    public DateTime FechaHoraActualizacion { get; set; }

    [InverseProperty("IdDocumentoNavigation")]
    public virtual ICollection<DocumentoDerivacione> DocumentoDerivaciones { get; set; } = new List<DocumentoDerivacione>();

    [ForeignKey("Estado")]
    [InverseProperty("Documentos")]
    public virtual EstadoDocumento EstadoNavigation { get; set; } = null!;

    [ForeignKey("IdAreaAsigando")]
    [InverseProperty("DocumentoIdAreaAsigandoNavigations")]
    public virtual Area? IdAreaAsigandoNavigation { get; set; }

    [ForeignKey("IdAreaOrigen")]
    [InverseProperty("DocumentoIdAreaOrigenNavigations")]
    public virtual Area? IdAreaOrigenNavigation { get; set; }

    [ForeignKey("IdFormaRecepcion")]
    [InverseProperty("Documentos")]
    public virtual FormaRecepcion IdFormaRecepcionNavigation { get; set; } = null!;

    [ForeignKey("IdPersonaAsignada")]
    [InverseProperty("DocumentoIdPersonaAsignadaNavigations")]
    public virtual Persona? IdPersonaAsignadaNavigation { get; set; }

    [ForeignKey("IdPersonaOrigen")]
    [InverseProperty("DocumentoIdPersonaOrigenNavigations")]
    public virtual Persona? IdPersonaOrigenNavigation { get; set; }

    [ForeignKey("IdPrioridad")]
    [InverseProperty("Documentos")]
    public virtual Prioridad IdPrioridadNavigation { get; set; } = null!;

    [ForeignKey("IdTipoDocumento")]
    [InverseProperty("Documentos")]
    public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuarioActualiza")]
    [InverseProperty("DocumentoIdUsuarioActualizaNavigations")]
    public virtual Usuario? IdUsuarioActualizaNavigation { get; set; }

    [ForeignKey("IdUsuarioRegistro")]
    [InverseProperty("DocumentoIdUsuarioRegistroNavigations")]
    public virtual Usuario? IdUsuarioRegistroNavigation { get; set; }

    [ForeignKey("Origen")]
    [InverseProperty("Documentos")]
    public virtual Origen OrigenNavigation { get; set; } = null!;
}
