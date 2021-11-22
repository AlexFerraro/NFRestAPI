using Microsoft.EntityFrameworkCore;
using NFRestAPI.Infrastructure.EntityTypes;

#nullable disable

namespace NFRestAPI.Infrastructure.Contexts
{
    public partial class VendasDBContext : DbContext
    {
        public VendasDBContext()
        {
        }

        public VendasDBContext(DbContextOptions<VendasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NotaFiscal> NotaFiscal { get; set; }
        public virtual DbSet<Notafiscalitens> Notafiscalitens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<NotaFiscal>(entity =>
            {
                entity.HasKey(e => e.Codnota)
                    .HasName("PK__NOTA_FIS__D3239CAC18445943");

                entity.ToTable("NOTA_FISCAL");

                entity.Property(e => e.Codnota)
                    .ValueGeneratedNever()
                    .HasColumnName("CODNOTA");

                entity.Property(e => e.Codvenda).HasColumnName("CODVENDA");

                entity.Property(e => e.Destinatarioremetente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESTINATARIOREMETENTE");

                entity.Property(e => e.Dtemissao)
                    .HasColumnType("date")
                    .HasColumnName("DTEMISSAO");

                entity.Property(e => e.Dtsaidaentrada)
                    .HasColumnType("date")
                    .HasColumnName("DTSAIDAENTRADA");

                entity.Property(e => e.Numerorecibo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMERORECIBO");

                entity.Property(e => e.Numnota).HasColumnName("NUMNOTA");

                entity.Property(e => e.Transfrete).HasColumnName("TRANSFRETE");

                entity.Property(e => e.Valortotalnota).HasColumnName("VALORTOTALNOTA");

                entity.Property(e => e.Valortotalprodutos).HasColumnName("VALORTOTALPRODUTOS");
            });

            modelBuilder.Entity<Notafiscalitens>(entity =>
            {
                entity.HasKey(e => e.Coditem)
                    .HasName("PK__NOTAFISC__3AC3A5BB8589B58A");

                entity.ToTable("NOTAFISCALITENS");

                entity.Property(e => e.Coditem)
                    .ValueGeneratedNever()
                    .HasColumnName("CODITEM");

                entity.Property(e => e.Codigoprodutoexterno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CODIGOPRODUTOEXTERNO");

                entity.Property(e => e.Codnota).HasColumnName("CODNOTA");

                entity.Property(e => e.Codpro).HasColumnName("CODPRO");

                entity.Property(e => e.Descrpro)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("DESCRPRO");

                entity.Property(e => e.Qtde).HasColumnName("QTDE");

                entity.Property(e => e.Unidade)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("UNIDADE");

                entity.Property(e => e.Valortotal).HasColumnName("VALORTOTAL");

                entity.Property(e => e.Valorunitario).HasColumnName("VALORUNITARIO");

                entity.HasOne(d => d.CodnotaNavigation)
                    .WithMany(p => p.Notafiscalitens)
                    .HasForeignKey(d => d.Codnota)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NOTAFISCALITENS_NOTAFISCAL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}