using Microsoft.EntityFrameworkCore;
using PociDelivery.Models;

namespace PociDelivery.Data
{
    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Perdoruesi> Perdoruesit { get; set; }
        public DbSet<Roli> Rolet { get; set; }
        public DbSet<PikaPostare> PikatPostare { get; set; }
        public DbSet<ZonaMbulimit> ZonatMbulimit { get; set; }
        public DbSet<Dergesa> Dergesat { get; set; }
        public DbSet<Reporti> Reportet { get; set; }
        public DbSet<Statusi> Statuset { get; set; }
        public DbSet<StatusiDergesa> StatusetDergesa { get; set; }
        public DbSet<Paketa> Paketat { get; set; }
        public DbSet<StatusiPaketa> StatusetPaketa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perdoruesi>()
                    .HasOne(p => p.Roli)
                    .WithMany(r => r.Perdoruesit)  // This assumes one-to-many
                    .HasForeignKey(p => p.IDRoli)
                    .OnDelete(DeleteBehavior.Restrict);

            // Lidhja e tabeles PD_Dergesa me  IDKlienti
            modelBuilder.Entity<Dergesa>()
                .HasOne(d => d.Klient)
                .WithMany(p => p.Klient)
                .HasForeignKey(d => d.IDKlienti)
                .OnDelete(DeleteBehavior.Restrict);

            // Lidhja e tabeles PD_Dergesa me IDSportelisti
            modelBuilder.Entity<Dergesa>()
                .HasOne(d => d.Sportelist)
                .WithMany(p => p.Sportelist)
                .HasForeignKey(d => d.IDSportelisti)
                .OnDelete(DeleteBehavior.Restrict);

            // Lidhja e tabeles PD_Paketa me  IDPikaPostareFillim
            modelBuilder.Entity<Paketa>()
                .HasOne(p => p.PikaPostareFillim)
                .WithMany(pp => pp.PaketatFillim)
                .HasForeignKey(p => p.IDPikaPostareFillim)
                .OnDelete(DeleteBehavior.Restrict);

            // Lidhja e tabeles PD_Paketa me  IDPikaPostareFund
            modelBuilder.Entity<Paketa>()
                .HasOne(p => p.PikaPostareFund)
                .WithMany(pp => pp.PaketatFund)
                .HasForeignKey(p => p.IDPikaPostareFund)
                .OnDelete(DeleteBehavior.Restrict);

            //vendosja kushtit nese fshihet nje rekord i PD_Statuset
            modelBuilder.Entity<StatusiDergesa>()
                    .HasOne(sd => sd.Statusi)
                    .WithMany(s => s.StatusiDergesa)
                    .HasForeignKey(sd => sd.IDStatusi)
                    .OnDelete(DeleteBehavior.Restrict); // Or .OnDelete(DeleteBehavior.NoAction)

            //vendosja kushtit nese fshihet nje rekord i PD_Statuset
            modelBuilder.Entity<StatusiPaketa>()
                .HasOne(sp => sp.Statusi)
                .WithMany(s => s.StatusiPaketa)
                .HasForeignKey(sp => sp.IDStatusi)
                .OnDelete(DeleteBehavior.Restrict); // Or .OnDelete(DeleteBehavior.NoAction)



            base.OnModelCreating(modelBuilder);
        }


    }
}
