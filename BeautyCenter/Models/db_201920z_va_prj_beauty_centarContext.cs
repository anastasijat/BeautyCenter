using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeautyCenter.Models
{
    public partial class db_201920z_va_prj_beauty_centarContext : DbContext
    {
        public db_201920z_va_prj_beauty_centarContext()
        {
        }

        public db_201920z_va_prj_beauty_centarContext(DbContextOptions<db_201920z_va_prj_beauty_centarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Direktor> Direktor { get; set; }
        public virtual DbSet<EOd> EOd { get; set; }
        public virtual DbSet<ImaZavrseno> ImaZavrseno { get; set; }
        public virtual DbSet<Klienti> Klienti { get; set; }
        public virtual DbSet<Kursevi> Kursevi { get; set; }
        public virtual DbSet<Menadzer> Menadzer { get; set; }
        public virtual DbSet<Oddeli> Oddeli { get; set; }
        public virtual DbSet<Odrzuva> Odrzuva { get; set; }
        public virtual DbSet<Omileni> Omileni { get; set; }
        public virtual DbSet<Opshtini> Opshtini { get; set; }
        public virtual DbSet<Posetuva> Posetuva { get; set; }
        public virtual DbSet<Predava> Predava { get; set; }
        public virtual DbSet<Predavaci> Predavaci { get; set; }
        public virtual DbSet<Prodavnica> Prodavnica { get; set; }
        public virtual DbSet<Proizvodi> Proizvodi { get; set; }
        public virtual DbSet<RabotniMesta> RabotniMesta { get; set; }
        public virtual DbSet<Saloni> Saloni { get; set; }
        public virtual DbSet<Termini> Termini { get; set; }
        public virtual DbSet<Uslugi> Uslugi { get; set; }
        public virtual DbSet<Vraboteni> Vraboteni { get; set; }
        public virtual DbSet<Vrsi> Vrsi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost; Database=db_201920z_va_prj_beauty_centar; Username=db_201920z_va_prj_beauty_centar_owner; Password=beauty_centar; Port=9999");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direktor>(entity =>
            {
                entity.HasKey(e => e.IdVrabotenDirektor)
                    .HasName("direktor_pkey");

                entity.ToTable("direktor", "project");

                entity.Property(e => e.IdVrabotenDirektor)
                    .HasColumnName("id_vraboten_direktor")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdVrabotenDirektorNavigation)
                    .WithOne(p => p.Direktor)
                    .HasForeignKey<Direktor>(d => d.IdVrabotenDirektor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_direktor_kon_vraboteni");
            });

            modelBuilder.Entity<EOd>(entity =>
            {
                entity.HasKey(e => new { e.IdProdavnica, e.IdProizvod })
                    .HasName("e_od_pkey");

                entity.ToTable("e_od", "project");

                entity.Property(e => e.IdProdavnica).HasColumnName("id_prodavnica");

                entity.Property(e => e.IdProizvod).HasColumnName("id_proizvod");

                entity.HasOne(d => d.IdProdavnicaNavigation)
                    .WithMany(p => p.EOd)
                    .HasForeignKey(d => d.IdProdavnica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("e_od_id_prodavnica_fkey");

                entity.HasOne(d => d.IdProizvodNavigation)
                    .WithMany(p => p.EOd)
                    .HasForeignKey(d => d.IdProizvod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("e_od_id_proizvod_fkey");
            });

            modelBuilder.Entity<ImaZavrseno>(entity =>
            {
                entity.HasKey(e => new { e.IdKlient, e.IdKurs })
                    .HasName("ima_zavrseno_pkey");

                entity.ToTable("ima_zavrseno", "project");

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.Property(e => e.IdKurs).HasColumnName("id_kurs");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.ImaZavrseno)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ima_zavrseno_id_klient_fkey");

                entity.HasOne(d => d.IdKursNavigation)
                    .WithMany(p => p.ImaZavrseno)
                    .HasForeignKey(d => d.IdKurs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ima_zavrseno_id_kurs_fkey");
            });

            modelBuilder.Entity<Klienti>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("klienti_pkey");

                entity.ToTable("klienti", "project");

                entity.HasIndex(e => e.EmailKlient)
                    .HasName("klienti_email_klient_key")
                    .IsUnique();

                entity.Property(e => e.IdKlient)
                    .HasColumnName("id_klient")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmailKlient)
                    .IsRequired()
                    .HasColumnName("email_klient")
                    .HasMaxLength(30);

                entity.Property(e => e.IdOpshtinaZhiveenje).HasColumnName("id_opshtina_zhiveenje");

                entity.Property(e => e.ImeKlient)
                    .IsRequired()
                    .HasColumnName("ime_klient")
                    .HasMaxLength(30);

                entity.Property(e => e.PasswordKlient)
                    .IsRequired()
                    .HasColumnName("password_klient")
                    .HasMaxLength(30);

                entity.Property(e => e.TelBrojKlient)
                    .HasColumnName("tel_broj_klient")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOpshtinaZhiveenjeNavigation)
                    .WithMany(p => p.Klienti)
                    .HasForeignKey(d => d.IdOpshtinaZhiveenje)
                    .HasConstraintName("fk_opstina_kon_klient");
            });

            modelBuilder.Entity<Kursevi>(entity =>
            {
                entity.HasKey(e => e.IdKurs)
                    .HasName("kursevi_pkey");

                entity.ToTable("kursevi", "project");

                entity.Property(e => e.IdKurs)
                    .HasColumnName("id_kurs")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaKurs).HasColumnName("cena_kurs");

                entity.Property(e => e.ImeKurs)
                    .IsRequired()
                    .HasColumnName("ime_kurs")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Menadzer>(entity =>
            {
                entity.HasKey(e => e.IdVrabotenMenadzer)
                    .HasName("menadzer_pkey");

                entity.ToTable("menadzer", "project");

                entity.Property(e => e.IdVrabotenMenadzer)
                    .HasColumnName("id_vraboten_menadzer")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdVrabotenMenadzerNavigation)
                    .WithOne(p => p.Menadzer)
                    .HasForeignKey<Menadzer>(d => d.IdVrabotenMenadzer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("menadzer_id_vraboten_menadzer_fkey");
            });

            modelBuilder.Entity<Oddeli>(entity =>
            {
                entity.HasKey(e => e.IdOddel)
                    .HasName("oddeli_pkey");

                entity.ToTable("oddeli", "project");

                entity.Property(e => e.IdOddel)
                    .HasColumnName("id_oddel")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdRm).HasColumnName("id_rm");

                entity.Property(e => e.IdSalon).HasColumnName("id_salon");

                entity.Property(e => e.IdVrabotenMenadzer).HasColumnName("id_vraboten_menadzer");

                entity.Property(e => e.ImeOddel)
                    .IsRequired()
                    .HasColumnName("ime_oddel")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdRmNavigation)
                    .WithMany(p => p.Oddeli)
                    .HasForeignKey(d => d.IdRm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("oddeli_id_rm_fkey");

                entity.HasOne(d => d.IdSalonNavigation)
                    .WithMany(p => p.Oddeli)
                    .HasForeignKey(d => d.IdSalon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("oddeli_id_salon_fkey");

                entity.HasOne(d => d.IdVrabotenMenadzerNavigation)
                    .WithMany(p => p.Oddeli)
                    .HasForeignKey(d => d.IdVrabotenMenadzer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("oddeli_id_vraboten_menadzer_fkey");
            });

            modelBuilder.Entity<Odrzuva>(entity =>
            {
                entity.HasKey(e => new { e.IdSalon, e.IdKurs })
                    .HasName("odrzuva_pkey");

                entity.ToTable("odrzuva", "project");

                entity.Property(e => e.IdSalon).HasColumnName("id_salon");

                entity.Property(e => e.IdKurs).HasColumnName("id_kurs");

                entity.HasOne(d => d.IdKursNavigation)
                    .WithMany(p => p.Odrzuva)
                    .HasForeignKey(d => d.IdKurs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("odrzuva_id_kurs_fkey");

                entity.HasOne(d => d.IdSalonNavigation)
                    .WithMany(p => p.Odrzuva)
                    .HasForeignKey(d => d.IdSalon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("odrzuva_id_salon_fkey");
            });

            modelBuilder.Entity<Omileni>(entity =>
            {
                entity.HasKey(e => new { e.IdKlient, e.IdUsluga })
                    .HasName("omileni_pkey");

                entity.ToTable("omileni", "project");

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.Property(e => e.IdUsluga).HasColumnName("id_usluga");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Omileni)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("omileni_id_klient_fkey");

                entity.HasOne(d => d.IdUslugaNavigation)
                    .WithMany(p => p.Omileni)
                    .HasForeignKey(d => d.IdUsluga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("omileni_id_usluga_fkey");
            });

            modelBuilder.Entity<Opshtini>(entity =>
            {
                entity.HasKey(e => e.IdOpshtina)
                    .HasName("opshtini_pkey");

                entity.ToTable("opshtini", "project");

                entity.Property(e => e.IdOpshtina)
                    .HasColumnName("id_opshtina")
                    .ValueGeneratedNever();

                entity.Property(e => e.Grad)
                    .HasColumnName("grad")
                    .HasMaxLength(30);

                entity.Property(e => e.NazivOpshtina)
                    .HasColumnName("naziv_opshtina")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Posetuva>(entity =>
            {
                entity.HasKey(e => new { e.IdKlient, e.IdKurs })
                    .HasName("posetuva_pkey");

                entity.ToTable("posetuva", "project");

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.Property(e => e.IdKurs).HasColumnName("id_kurs");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Posetuva)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("posetuva_id_klient_fkey");

                entity.HasOne(d => d.IdKursNavigation)
                    .WithMany(p => p.Posetuva)
                    .HasForeignKey(d => d.IdKurs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("posetuva_id_kurs_fkey");
            });

            modelBuilder.Entity<Predava>(entity =>
            {
                entity.HasKey(e => new { e.IdPredavac, e.IdKurs })
                    .HasName("predava_pkey");

                entity.ToTable("predava", "project");

                entity.Property(e => e.IdPredavac).HasColumnName("id_predavac");

                entity.Property(e => e.IdKurs).HasColumnName("id_kurs");

                entity.HasOne(d => d.IdKursNavigation)
                    .WithMany(p => p.Predava)
                    .HasForeignKey(d => d.IdKurs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("predava_id_kurs_fkey");

                entity.HasOne(d => d.IdPredavacNavigation)
                    .WithMany(p => p.Predava)
                    .HasForeignKey(d => d.IdPredavac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("predava_id_predavac_fkey");
            });

            modelBuilder.Entity<Predavaci>(entity =>
            {
                entity.HasKey(e => e.IdPredavac)
                    .HasName("predavaci_pkey");

                entity.ToTable("predavaci", "project");

                entity.HasIndex(e => e.EmailPredavac)
                    .HasName("predavaci_email_predavac_key")
                    .IsUnique();

                entity.Property(e => e.IdPredavac)
                    .HasColumnName("id_predavac")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmailPredavac)
                    .IsRequired()
                    .HasColumnName("email_predavac")
                    .HasMaxLength(30);

                entity.Property(e => e.ImePredavac)
                    .IsRequired()
                    .HasColumnName("ime_predavac")
                    .HasMaxLength(30);

                entity.Property(e => e.Iskustvo)
                    .HasColumnName("iskustvo")
                    .HasMaxLength(30);

                entity.Property(e => e.TelBrojPredavac)
                    .HasColumnName("tel_broj_predavac")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Prodavnica>(entity =>
            {
                entity.HasKey(e => e.IdProdavnica)
                    .HasName("prodavnica_pkey");

                entity.ToTable("prodavnica", "project");

                entity.Property(e => e.IdProdavnica)
                    .HasColumnName("id_prodavnica")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdSalon).HasColumnName("id_salon");

                entity.Property(e => e.ImeProdavnica)
                    .IsRequired()
                    .HasColumnName("ime_prodavnica")
                    .HasMaxLength(30);

                entity.Property(e => e.Lokacija)
                    .HasColumnName("lokacija")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdSalonNavigation)
                    .WithMany(p => p.Prodavnica)
                    .HasForeignKey(d => d.IdSalon)
                    .HasConstraintName("fk_salon_kon_prodavnica");
            });

            modelBuilder.Entity<Proizvodi>(entity =>
            {
                entity.HasKey(e => e.IdProizvod)
                    .HasName("proizvodi_pkey");

                entity.ToTable("proizvodi", "project");

                entity.Property(e => e.IdProizvod)
                    .HasColumnName("id_proizvod")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaProizvod).HasColumnName("cena_proizvod");

                entity.Property(e => e.ImeProizvod)
                    .IsRequired()
                    .HasColumnName("ime_proizvod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<RabotniMesta>(entity =>
            {
                entity.HasKey(e => e.IdRm)
                    .HasName("rabotni_mesta_pkey");

                entity.ToTable("rabotni_mesta", "project");

                entity.Property(e => e.IdRm)
                    .HasColumnName("id_rm")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImeRm)
                    .IsRequired()
                    .HasColumnName("ime_rm")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Saloni>(entity =>
            {
                entity.HasKey(e => e.IdSalon)
                    .HasName("saloni_pkey");

                entity.ToTable("saloni", "project");

                entity.Property(e => e.IdSalon)
                    .HasColumnName("id_salon")
                    .ValueGeneratedNever();

                entity.Property(e => e.Broj)
                    .HasColumnName("broj")
                    .HasMaxLength(30);

                entity.Property(e => e.IdOpshtina).HasColumnName("id_opshtina");

                entity.Property(e => e.IdVrabotenDirektor).HasColumnName("id_vraboten_direktor");

                entity.Property(e => e.ImeSalon)
                    .IsRequired()
                    .HasColumnName("ime_salon")
                    .HasMaxLength(30);

                entity.Property(e => e.TelBrojSalon)
                    .HasColumnName("tel_broj_salon")
                    .HasMaxLength(30);

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasColumnName("ulica")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOpshtinaNavigation)
                    .WithMany(p => p.Saloni)
                    .HasForeignKey(d => d.IdOpshtina)
                    .HasConstraintName("fk_opstina_kon_salon");

                entity.HasOne(d => d.IdVrabotenDirektorNavigation)
                    .WithMany(p => p.Saloni)
                    .HasForeignKey(d => d.IdVrabotenDirektor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_saloni_kon_direktor");
            });

            modelBuilder.Entity<Termini>(entity =>
            {
                entity.HasKey(e => e.IdTermin)
                    .HasName("termini_pkey");

                entity.ToTable("termini", "project");

                entity.Property(e => e.IdTermin)
                    .HasColumnName("id_termin")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.IdKlient).HasColumnName("id_klient");

                entity.Property(e => e.IdUsluga).HasColumnName("id_usluga");

                entity.Property(e => e.IdVraboten).HasColumnName("id_vraboten");

                entity.Property(e => e.Komentar)
                    .HasColumnName("komentar")
                    .HasMaxLength(100);

                entity.Property(e => e.Ocenka).HasColumnName("ocenka");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20);

                entity.Property(e => e.Vreme)
                    .HasColumnName("vreme")
                    .HasColumnType("time without time zone");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Termini)
                    .HasForeignKey(d => d.IdKlient)
                    .HasConstraintName("termini_id_klient_fkey");

                entity.HasOne(d => d.IdUslugaNavigation)
                    .WithMany(p => p.Termini)
                    .HasForeignKey(d => d.IdUsluga)
                    .HasConstraintName("termini_id_usluga_fkey");

                entity.HasOne(d => d.IdVrabotenNavigation)
                    .WithMany(p => p.Termini)
                    .HasForeignKey(d => d.IdVraboten)
                    .HasConstraintName("termini_id_vraboten_fkey");
            });

            modelBuilder.Entity<Uslugi>(entity =>
            {
                entity.HasKey(e => e.IdUsluga)
                    .HasName("uslugi_pkey");

                entity.ToTable("uslugi", "project");

                entity.Property(e => e.IdUsluga)
                    .HasColumnName("id_usluga")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaUsluga).HasColumnName("cena_usluga");

                entity.Property(e => e.IdOddel).HasColumnName("id_oddel");

                entity.Property(e => e.ImeUsluga)
                    .IsRequired()
                    .HasColumnName("ime_usluga")
                    .HasMaxLength(30);

                entity.Property(e => e.OpisUsluga)
                    .HasColumnName("opis_usluga")
                    .HasMaxLength(70);

                entity.HasOne(d => d.IdOddelNavigation)
                    .WithMany(p => p.Uslugi)
                    .HasForeignKey(d => d.IdOddel)
                    .HasConstraintName("uslugi_id_oddel_fkey");
            });

            modelBuilder.Entity<Vraboteni>(entity =>
            {
                entity.HasKey(e => e.IdVraboten)
                    .HasName("vraboteni_pkey");

                entity.ToTable("vraboteni", "project");

                entity.HasIndex(e => e.EmailVraboten)
                    .HasName("vraboteni_email_vraboten_key")
                    .IsUnique();

                entity.Property(e => e.IdVraboten)
                    .HasColumnName("id_vraboten")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmailVraboten)
                    .IsRequired()
                    .HasColumnName("email_vraboten")
                    .HasMaxLength(30);

                entity.Property(e => e.IdRm).HasColumnName("id_rm");

                entity.Property(e => e.IdSalon).HasColumnName("id_salon");

                entity.Property(e => e.ImeVraboten)
                    .IsRequired()
                    .HasColumnName("ime_vraboten")
                    .HasMaxLength(30);

                entity.Property(e => e.MesecnaPlata).HasColumnName("mesecna_plata");

                entity.Property(e => e.PasswordVraboten)
                    .IsRequired()
                    .HasColumnName("password_vraboten")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdRmNavigation)
                    .WithMany(p => p.Vraboteni)
                    .HasForeignKey(d => d.IdRm)
                    .HasConstraintName("fk_vraboten_kon_rm");

                entity.HasOne(d => d.IdSalonNavigation)
                    .WithMany(p => p.Vraboteni)
                    .HasForeignKey(d => d.IdSalon)
                    .HasConstraintName("fk_vraboten_kon_salon");
            });

            modelBuilder.Entity<Vrsi>(entity =>
            {
                entity.HasKey(e => new { e.IdUsluga, e.IdRm })
                    .HasName("vrsi_pkey");

                entity.ToTable("vrsi", "project");

                entity.Property(e => e.IdUsluga).HasColumnName("id_usluga");

                entity.Property(e => e.IdRm).HasColumnName("id_rm");

                entity.HasOne(d => d.IdRmNavigation)
                    .WithMany(p => p.Vrsi)
                    .HasForeignKey(d => d.IdRm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vrsi_id_rm_fkey");

                entity.HasOne(d => d.IdUslugaNavigation)
                    .WithMany(p => p.Vrsi)
                    .HasForeignKey(d => d.IdUsluga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vrsi_id_usluga_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
