using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BDTramiteDocumentarioModel;

public partial class _dbTramiteDocumentarioContext : DbContext
{
    public _dbTramiteDocumentarioContext()
    {
    }

    public _dbTramiteDocumentarioContext(DbContextOptions<_dbTramiteDocumentarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<CalificacionTupa> CalificacionTupas { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Colaborador> Colaboradors { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<DocumentoDerivacione> DocumentoDerivaciones { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<EstadoDocumento> EstadoDocumentos { get; set; }

    public virtual DbSet<FormaAsignacion> FormaAsignacions { get; set; }

    public virtual DbSet<FormaRecepcion> FormaRecepcions { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Organizacion> Organizacions { get; set; }

    public virtual DbSet<Origen> Origens { get; set; }

    public virtual DbSet<PersonTipo> PersonTipos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonaGenero> PersonaGeneros { get; set; }

    public virtual DbSet<PersonaTipoDocumento> PersonaTipoDocumentos { get; set; }

    public virtual DbSet<Prioridad> Prioridads { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Ubigeo> Ubigeos { get; set; }

    public virtual DbSet<UserSesion> UserSesions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VPersona> VPersonas { get; set; }

    public virtual DbSet<VUsuario> VUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=tramite_documentario;Integrated Security=True;Trusted_Connection=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__area__3213E83F808B29D6");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<CalificacionTupa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__califica__3213E83F720823F7");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cargo__3213E83FA3EEBEE0");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Colaborador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__colabora__3213E83F90C23A58");

            entity.Property(e => e.FechaActualiza).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaCrea).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Colaboradors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__colaborad__id_ar__681373AD");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Colaboradors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__colaborad__id_ca__671F4F74");

            entity.HasOne(d => d.IdPersonaNavigation).WithOne(p => p.Colaborador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__colaborad__id_pe__662B2B3B");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__document__3213E83F0C8B2390");

            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaDocumento).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaHoraActualizacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.HoraRegistro).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Documentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__documento__estad__75F77EB0");

            entity.HasOne(d => d.IdAreaAsigandoNavigation).WithMany(p => p.DocumentoIdAreaAsigandoNavigations).HasConstraintName("FK__documento__id_ar__740F363E");

            entity.HasOne(d => d.IdAreaOrigenNavigation).WithMany(p => p.DocumentoIdAreaOrigenNavigations).HasConstraintName("FK__documento__id_ar__731B1205");

            entity.HasOne(d => d.IdFormaRecepcionNavigation).WithMany(p => p.Documentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__documento__id_fo__6D6238AF");

            entity.HasOne(d => d.IdPersonaAsignadaNavigation).WithMany(p => p.DocumentoIdPersonaAsignadaNavigations).HasConstraintName("FK__documento__id_pe__75035A77");

            entity.HasOne(d => d.IdPersonaOrigenNavigation).WithMany(p => p.DocumentoIdPersonaOrigenNavigations).HasConstraintName("FK__documento__id_pe__7226EDCC");

            entity.HasOne(d => d.IdPrioridadNavigation).WithMany(p => p.Documentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__documento__id_pr__6C6E1476");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Documentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__documento__id_ti__6B79F03D");

            entity.HasOne(d => d.IdUsuarioActualizaNavigation).WithMany(p => p.DocumentoIdUsuarioActualizaNavigations).HasConstraintName("FK__documento__id_us__78D3EB5B");

            entity.HasOne(d => d.IdUsuarioRegistroNavigation).WithMany(p => p.DocumentoIdUsuarioRegistroNavigations).HasConstraintName("FK__documento__id_us__77DFC722");

            entity.HasOne(d => d.OrigenNavigation).WithMany(p => p.Documentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__documento__orige__7132C993");
        });

        modelBuilder.Entity<DocumentoDerivacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__document__3213E83F59131218");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.DocumentoDerivaciones).HasConstraintName("FK__documento__id_ar__7E8CC4B1");

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.DocumentoDerivaciones).HasConstraintName("FK__documento__id_do__7CA47C3F");

            entity.HasOne(d => d.IdDocumentoFormaAsignacionNavigation).WithMany(p => p.DocumentoDerivaciones).HasConstraintName("FK__documento__id_do__7D98A078");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__error__3213E83FEB11BBE2");

            entity.Property(e => e.FechaActualiza).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaCrea).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Errors).HasConstraintName("FK__error__id_person__55F4C372");

            entity.HasOne(d => d.UsuarioActualizaNavigation).WithMany(p => p.ErrorUsuarioActualizaNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__error__usuario_a__57DD0BE4");

            entity.HasOne(d => d.UsuarioCreaNavigation).WithMany(p => p.ErrorUsuarioCreaNavigations).HasConstraintName("FK__error__usuario_c__56E8E7AB");
        });

        modelBuilder.Entity<EstadoDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__estado_d__3213E83F9642696A");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<FormaAsignacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__forma_as__3213E83F89A1FCF3");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<FormaRecepcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__forma_re__3213E83FE4CC8629");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menu__3213E83F756C5638");

            entity.Property(e => e.FechaActualiza).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaCrea).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menu_rol__3213E83FEAA5C9A6");

            entity.Property(e => e.FechaActualiza).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaCrea).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__menu_rol__id_men__160F4887");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__menu_rol__id_rol__151B244E");
        });

        modelBuilder.Entity<Organizacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__organiza__3213E83FD9F94152");
        });

        modelBuilder.Entity<Origen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__origen__3213E83FA9A2AA7C");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<PersonTipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__person_t__3213E83F2AB67B8F");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__persona__3213E83F9A2ECF6E");

            entity.Property(e => e.FechaActualiza).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaCrea).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__persona__id_gene__787EE5A0");

            entity.HasOne(d => d.IdPersonaTipoNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__persona__id_pers__778AC167");

            entity.HasOne(d => d.IdPersonaTipoDocumentoNavigation).WithMany(p => p.Personas).HasConstraintName("FK__persona__id_pers__76969D2E");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.Personas).HasConstraintName("FK__persona__id_ubig__797309D9");
        });

        modelBuilder.Entity<PersonaGenero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__persona___3213E83FB3843BD0");
        });

        modelBuilder.Entity<PersonaTipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__persona___3213E83F6DFB81E9");
        });

        modelBuilder.Entity<Prioridad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__priorida__3213E83F049EA21C");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rol__3213E83F5DDC6E00");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipo_doc__3213E83F3C357F96");

            entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ubigeo__3213E83F37CAFC62");
        });

        modelBuilder.Entity<UserSesion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_ses__3213E83FDE3D084A");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserSesions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_sesi__id_us__5CA1C101");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83F183D521E");

            entity.Property(e => e.ChangePassword).HasDefaultValueSql("((0))");
            entity.Property(e => e.FechaActualiza).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaCrea).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__id_pers__4C6B5938");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__id_rol__4E53A1AA");
        });

        modelBuilder.Entity<VPersona>(entity =>
        {
            entity.ToView("V_Persona");
        });

        modelBuilder.Entity<VUsuario>(entity =>
        {
            entity.ToView("V_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
