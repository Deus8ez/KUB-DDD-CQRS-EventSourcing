using System;
using System.Collections;
using System.Collections.Generic;
using KUB.Core.Models;
using KUB.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#nullable disable

namespace KUB.Infrastructure.Data
{
    public class ManagementGamesDB : DbContext
    {
        public ManagementGamesDB()
        {
        }

        public ManagementGamesDB(DbContextOptions<ManagementGamesDB> options)
            : base(options)
        {
        }
        public virtual DbSet<BaseEvent> Events { get; set; }
        public virtual DbSet<JuryInPanel> JuryInPanels { get; set; }
        public virtual DbSet<JuryPanel> JuryPanels { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<ParticipantInSchool> ParticipantInSchools { get; set; }
        public virtual DbSet<ParticipantInTournament> ParticipantInTournaments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<TournamentFormat> TournamentFormats { get; set; }
        public virtual DbSet<TournamentGridType> TournamentGridTypes { get; set; }
        public virtual DbSet<TournamentType> TournamentTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:kub-db.database.windows.net,1433;Initial Catalog=kub-db;Persist Security Info=False;User ID=kubadmin;Password=Univerza_maribor_123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var offline = new TournamentFormat
            {
                Id = Guid.NewGuid(),
                Format = "Оффлайн"
            };

            modelBuilder.Entity<TournamentFormat>().HasData(
                    offline,
                    new TournamentFormat
                    {
                        Id = Guid.NewGuid(),
                        Format = "Онлайн"
                    },
                    new TournamentFormat
                    {
                        Id = Guid.NewGuid(),
                        Format = "Гибридный"
                    }
            );

            var practice = new TournamentType
            {
                Id = Guid.NewGuid(),
                Type = "Практикум"
            };
            modelBuilder.Entity<TournamentType>().HasData(
                    practice,
                    new TournamentType
                    {
                        Id = Guid.NewGuid(),
                        Type = "Товарищеский"
                    },
                    new TournamentType
                    {
                        Id = Guid.NewGuid(),
                        Type = "Именной"
                    },
                    new TournamentType
                    {
                        Id = Guid.NewGuid(),
                        Type = "Отборочный"
                    },
                    new TournamentType
                    {
                        Id = Guid.NewGuid(),
                        Type = "Финал года"
                    }
            );

            modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "Не выбрана"
                    },
                    new Role
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "Зритель"
                    },
                    new Role
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "Игрок"
                    },
                    new Role
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "Секундант"
                    },
                    new Role
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "Судья"
                    },
                    new Role
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "Арбитр"
                    },
                    new Role
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "Секретарь"
                    },
                    new Role
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "Тренер"
                    }
            );

            modelBuilder.Entity<JuryPanel>().HasData(
                    new JuryPanel
                    {
                        Id = Guid.NewGuid(),
                        Panel = "Нанимающиеся на работу"
                    },
                    new JuryPanel
                    {
                        Id = Guid.NewGuid(),
                        Panel = "Направляющие на переговоры"
                    },
                    new JuryPanel
                    {
                        Id = Guid.NewGuid(),
                        Panel = "Направляющие на переговоры"
                    }
            );

            var teams = new TournamentGridType
            {
                Id = Guid.NewGuid(),
                Type = "По командам"
            };
            modelBuilder.Entity<TournamentGridType>().HasData(
                    new TournamentGridType
                    {
                        Id = Guid.NewGuid(),
                        Type = "Каждый с каждым"
                    },
                    new TournamentGridType
                    {
                        Id = Guid.NewGuid(),
                        Type = "Навылет"
                    },
                    teams,
                    new TournamentGridType
                    {
                        Id = Guid.NewGuid(),
                        Type = "Комбинированный"
                    }
            );

            modelBuilder.Entity<School>().HasData(
                    new School
                    {
                        Id = Guid.NewGuid(),
                        SchoolName = "Нет школы"
                    }
                );

            var tournaments = new List<Tournament>();

            for(int i = 0; i < 1; i++)
            {
                tournaments.Add(new Tournament
                {
                    Id = Guid.NewGuid(),
                    Date = new DateTime(),
                    EndTime = new TimeSpan(0, 0, 0, 0),
                    StartTime = new TimeSpan(0, 0, 0, 0),
                    TournamentFormatId = offline.Id,
                    TournamentGridId = teams.Id,
                    TournamentName = "Турнир в Томске" + i,
                    TournamentTypeId = practice.Id,
                    Number = i,
                    Address = "Пушкина" + i,
                    City = "Томск"
                });
            };

            modelBuilder.Entity<Tournament>().HasData(
                    tournaments
                );

            modelBuilder.Entity<Participant>().HasData(
                    new Participant
                    {
                        Id = Guid.NewGuid(),
                        BlitzGameRank = 1,
                        CanBeAJury = true,
                        ClassicGameRank = 1,    
                        DateOfBirth = new DateTime(),
                        Name = "Иван",
                        Patronym = "Иванович",
                        Surname = "Иванов",
                    }
                );

            //modelBuilder.Entity<JuryInPanel>(entity =>
            //{
            //    entity.HasOne(d => d.JuryPanel)
            //        .WithMany(p => p.JuryInPanels)
            //        .HasForeignKey(d => d.JuryPanelId)
            //        .HasConstraintName("FK_Судьи в коллегиях_Коллегии судей");

            //    entity.HasOne(d => d.JuryParticipant)
            //        .WithMany(p => p.JuryInPanels)
            //        .HasForeignKey(d => d.JuryParticipantId)
            //        .HasConstraintName("FK_Судьи в коллегиях_Участники1");

            //    entity.HasOne(d => d.TournamentWithJury)
            //        .WithMany(p => p.JuryInPanels)
            //        .HasForeignKey(d => d.TournamentWithJuryId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Судьи в коллегиях_Турниры");
            //});

            //modelBuilder.Entity<JuryPanel>(entity =>
            //{
            //    entity.HasKey(e => e.PanelId)
            //        .HasName("PK_Коллегии судей");
            //});

            //modelBuilder.Entity<ParticipantInSchool>(entity =>
            //{
            //    entity.HasOne(d => d.ParticipantInSchoolNavigation)
            //        .WithOne(p => p.ParticipantInSchool)
            //        .HasForeignKey<ParticipantInSchool>(d => d.ParticipantInSchoolId)
            //        .HasConstraintName("FK_Участники в школах_Участники");

            //    entity.HasOne(d => d.ParticipantSchool)
            //        .WithMany(p => p.ParticipantInSchools)
            //        .HasForeignKey(d => d.ParticipantSchoolId)
            //        .HasConstraintName("FK_Участники в школах_Школы");
            //});

            //modelBuilder.Entity<ParticipantInTournament>(entity =>
            //{
            //    entity.HasKey(e => new { e.TournamentId, e.ParticipantId })
            //        .HasName("PK_Участники в турнирах");

            //    entity.HasOne(d => d.Participant)
            //        .WithMany(p => p.ParticipantInTournaments)
            //        .HasForeignKey(d => d.ParticipantId)
            //        .HasConstraintName("FK_Участники в турнирах_Участники");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.ParticipantInTournaments)
            //        .HasForeignKey(d => d.ParticipantId)
            //        .HasConstraintName("FK_Участники в турнирах_Роли");

            //    entity.HasOne(d => d.Tournament)
            //        .WithMany(p => p.ParticipantInTournaments)
            //        .HasForeignKey(d => d.Tournament)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Участники в турнирах_Турниры");
            //});

            //modelBuilder.Entity<Tournament>(entity =>
            //{
            //    entity.Property(e => e.EndTime).IsFixedLength(true);

            //    entity.Property(e => e.StartTime).IsFixedLength(true);

            //    entity.HasOne(d => d.TournamentFormat)
            //        .WithMany(p => p.Tournaments)
            //        .HasForeignKey(d => d.TournamentFormatId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Турниры_Формат проведения");

            //    entity.HasOne(d => d.TournamentGrid)
            //        .WithMany(p => p.Tournaments)
            //        .HasForeignKey(d => d.TournamentGridId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Турниры_Вариант сетки турнира");

            //    entity.HasOne(d => d.Location)
            //        .WithMany(p => p.Tournaments)
            //        .HasForeignKey(d => d.LocationId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Турниры_Место1");

            //    entity.HasOne(d => d.TournamentType)
            //        .WithMany(p => p.Tournaments)
            //        .HasForeignKey(d => d.TournamentTypeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Турниры_Типы турниров");
            //});

            //modelBuilder.Entity<TournamentFormat>(entity =>
            //{
            //    entity.HasKey(e => e.FormatId)
            //        .HasName("PK_Формат проведения");
            //});

            //modelBuilder.Entity<TournamentGridType>(entity =>
            //{
            //    entity.HasKey(e => e.GridId)
            //        .HasName("PK_Вариант сетки турнира");
            //});

            //modelBuilder.Entity<TournamentType>(entity =>
            //{
            //    entity.HasKey(e => e.TypeId)
            //        .HasName("PK_Типы турниров");
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
