using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApp.Models.db
{
    public partial class EboardingContext : DbContext
    {
        public EboardingContext()
        {
        }

        public EboardingContext(DbContextOptions<EboardingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airport> Airports { get; set; }

        public virtual DbSet<Flight> Flights { get; set; }

        public virtual DbSet<Passenger> Passengers { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server = DESKTOP-2CPE3OP;Database=Eboarding;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.AirportId).HasName("PK__Airports__E3DBE0EA74734DC3");

                entity.Property(e => e.AirportName).HasMaxLength(100);
                entity.Property(e => e.AirportSignal).HasMaxLength(100);
                entity.Property(e => e.Destination).HasMaxLength(100);
                entity.Property(e => e.FullDestination).HasMaxLength(100);
                entity.Property(e => e.Province).HasMaxLength(100);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FlightId).HasName("PK__Flights__8A9E14EE0039821D");

                entity.Property(e => e.FlightNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.PassId).HasName("PK__Passenge__C6740AA88629C925");

                entity.Property(e => e.PassName).HasMaxLength(100);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC6074BA8EB46");

                entity.Property(e => e.Boarding).HasColumnType("datetime");
                entity.Property(e => e.DepartDate).HasColumnType("datetime");
                entity.Property(e => e.Gate).HasMaxLength(10);
                entity.Property(e => e.SeatNumber).HasMaxLength(10);
                entity.Property(e => e.Seq).HasMaxLength(10);
                entity.Property(e => e.Zone).HasMaxLength(10);

                entity.HasOne(d => d.Airport).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.AirportId)
                    .HasConstraintName("FK__Tickets__Airport__4CA06362");

                entity.HasOne(d => d.Flight).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__Tickets__FlightI__4D94879B");

                entity.HasOne(d => d.Pass).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PassId)
                    .HasConstraintName("FK__Tickets__PassId__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
