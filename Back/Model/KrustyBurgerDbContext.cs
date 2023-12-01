using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back.Model;

public partial class KrustyBurgerDbContext : DbContext
{
    public KrustyBurgerDbContext()
    {
    }

    public KrustyBurgerDbContext(DbContextOptions<KrustyBurgerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Imagem> Imagems { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoProduto> PedidoProdutos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Promocao> Promocaos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-001YQ\\SQLEXPRESS01;Initial Catalog=KrustyBurgerDB;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Imagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imagem__3214EC272A7F3429");

            entity.ToTable("Imagem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Foto).IsRequired();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido__3214EC278091D0B5");

            entity.ToTable("Pedido");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HoraEntregue).HasColumnType("datetime");
            entity.Property(e => e.HoraPedido).HasColumnType("datetime");
            entity.Property(e => e.PedidoPronto).HasDefaultValueSql("((0))");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedido__UsuarioI__3C69FB99");
        });

        modelBuilder.Entity<PedidoProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PedidoPr__3214EC273B6541C3");

            entity.ToTable("PedidoProduto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");
            entity.Property(e => e.PromocaoId).HasColumnName("PromocaoID");

            entity.HasOne(d => d.Produto).WithMany(p => p.PedidoProdutos)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("FK__PedidoPro__Produ__45F365D3");

            entity.HasOne(d => d.Promocao).WithMany(p => p.PedidoProdutos)
                .HasForeignKey(d => d.PromocaoId)
                .HasConstraintName("FK__PedidoPro__Promo__46E78A0C");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC279870309B");

            entity.ToTable("Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.ImagemId).HasColumnName("ImagemID");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Imagem).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.ImagemId)
                .HasConstraintName("FK__Produto__ImagemI__403A8C7D");
        });

        modelBuilder.Entity<Promocao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocao__3214EC2763C166FE");

            entity.ToTable("Promocao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");

            entity.HasOne(d => d.Produto).WithMany(p => p.Promocaos)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("FK__Promocao__Produt__4316F928");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC273D38E3D6");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adm).HasDefaultValueSql("((0))");
            entity.Property(e => e.Cpf)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .IsRequired()
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
