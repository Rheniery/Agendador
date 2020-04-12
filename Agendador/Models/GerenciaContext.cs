using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Agendador.Models
{
    public partial class GerenciaContext : DbContext
    {
        public GerenciaContext()
        {
        }

        /// <summary>
        /// Construtor recebendo as opções de conexao e contexto
        /// </summary>
        /// <param name="options"></param>
        public GerenciaContext(DbContextOptions<GerenciaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        /// <summary>
        /// Configuração do Context
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=rheniery\\mssqlserver01;Database=Gerencia;Integrated Security=True");
            }
        }

        /// <summary>
        /// Construtor das models
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.Property(e => e.AgendaId)
                    .HasColumnName("AGENDA_ID")
                    .HasComment("Id da Agenda")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ClinicaId)
                    .HasColumnName("CLINICA_ID")
                    .HasComment("Id da Clínica");

                entity.Property(e => e.DataFimD)
                    .HasColumnName("DATA_FIM_D")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataInicioD)
                    .HasColumnName("DATA_INICIO_D")
                    .HasColumnType("datetime");

                entity.Property(e => e.IndrStatusN)
                    .HasColumnName("INDR_STATUS_N")
                    .HasColumnType("numeric(1, 0)");

                entity.Property(e => e.PacienteId)
                    .HasColumnName("PACIENTE_ID")
                    .HasComment("ID do Paciente");

                entity.HasOne(d => d.Clinica)
                    .WithMany(p => p.AgendaClinica)
                    .HasForeignKey(d => d.ClinicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agenda_Clinica");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.AgendaPaciente)
                    .HasForeignKey(d => d.PacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agenda_Paciente");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.Property(e => e.PessoaId)
                    .HasColumnName("PESSOA_ID")
                    .HasComment("Id da Pessoa")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DescConvenioA)
                    .HasColumnName("DESC_CONVENIO_A")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nome do Convênio");

                entity.Property(e => e.DescCpfcnpjA)
                    .IsRequired()
                    .HasColumnName("DESC_CPFCNPJ_A")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Descrição CPF ou CNPJ");

                entity.Property(e => e.DescEmailA)
                    .HasColumnName("DESC_EMAIL_A")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Descrição do Email");

                entity.Property(e => e.DescEnderecoA)
                    .HasColumnName("DESC_ENDERECO_A")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Descrição do Endereço");

                entity.Property(e => e.DescNomeA)
                    .IsRequired()
                    .HasColumnName("DESC_NOME_A")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Nome da Pessoa");

                entity.Property(e => e.DescNumconvenioA)
                    .HasColumnName("DESC_NUMCONVENIO_A")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Número do Convênio");

                entity.Property(e => e.DescTelefoneA)
                    .IsRequired()
                    .HasColumnName("DESC_TELEFONE_A")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Descrição Telefone");

                entity.Property(e => e.IndrConvenioA)
                    .HasColumnName("INDR_CONVENIO_A")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Indicador do Convênio: S-Sim e N-Não");

                entity.Property(e => e.IndrTipoA)
                    .IsRequired()
                    .HasColumnName("INDR_TIPO_A")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Indicador Tipo Pessoa: F-Física e J-Jurídica");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
