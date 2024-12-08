using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.DAL.DataBase
{
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Площадки.
        /// </summary>
        public DbSet<Ground> Grounds { get; set; }

        /// <summary>
        /// Профили пользователей.
        /// </summary>
        public DbSet<Profile> Profiles { get; set; }

        /// <summary>
        /// Параметры.
        /// </summary>
        public DbSet<Parameter> Parameters { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ground>()
                .HasIndex(g => g.Name)
                .IsUnique();

            //Я надеюсь что так сработает, но это вообще не факт.
            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.Property(e => e.ConcurrencyToken).IsRowVersion();
            });

            #region Комментарии 

            modelBuilder.Entity<Ground>().Property(u => u.Id).HasComment("Идентификатор");
            modelBuilder.Entity<Ground>().Property(u => u.Name).HasComment("Наименование");
            modelBuilder.Entity<Ground>().Property(u => u.Photos).HasComment("Фотографии");
            modelBuilder.Entity<Ground>().Property(u => u.GeneralDescription).HasComment("Общее описание");
            modelBuilder.Entity<Ground>().Property(u => u.Price).HasComment("Цена за один timeSlot");

            modelBuilder.Entity<Profile>().Property(u => u.Id).HasComment("Идентификатор");
            modelBuilder.Entity<Profile>().Property(u => u.Name).HasComment("Имя");
            modelBuilder.Entity<Profile>().Property(u => u.LastName).HasComment("Фамилия");
            modelBuilder.Entity<Profile>().Property(u => u.Email).HasComment("Email");
            modelBuilder.Entity<Profile>().Property(u => u.SocialNetworks).HasComment("Социальные сети");
            modelBuilder.Entity<Profile>().Property(u => u.PhoneNumber).HasComment("Номер телефона");

            modelBuilder.Entity<Parameter>().Property(u => u.Id).HasComment("Идентификатор");
            modelBuilder.Entity<Parameter>().Property(u => u.Name).HasComment("Наименование");
            modelBuilder.Entity<Parameter>().Property(u => u.Icon).HasComment("Иконка");

            #endregion
        }

    }
}
