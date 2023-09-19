using Microsoft.EntityFrameworkCore;
using LoginAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LoginAPI.Data
{
    public class AplicationDbContextUser : IdentityDbContext<IdentityUser>
    {
        //public DbSet<UserModel> User { get; set; }

        public AplicationDbContextUser(DbContextOptions<AplicationDbContextUser> context) : base(context)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot Configuration = new ConfigurationBuilder()
        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DatabaseUser"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<UserModel>().HasData(new UserModel
            //{
            //    Id = 1,
            //    Nome = "Igor Paim de Oliveira",
            //    Password = "password",
            //    Phone = "71999434958",
            //    Email = "igorpaimdeoliveira@gmail.com",
            //    DataCadastro = DateTime.Now,

            //});

            //modelBuilder.Entity<UserModel>().HasData(new UserModel
            //{
            //    Id = 2,
            //    Nome = "Rogerio Oliveira",
            //    Password = "password",
            //    Phone = "71999434958",
            //    Email = "Rogeriodeoliveira@gmail.com",
            //    DataCadastro = DateTime.Now,

            //});

            //modelBuilder.Entity<UserModel>().HasData(new UserModel
            //{
            //    Id = 3,
            //    Nome = "Magno Paim",
            //    Password = "password",
            //    Phone = "71999434958",
            //    Email = "Magnopaim@gmail.com",
            //    DataCadastro = DateTime.Now,

            //});
        }
    }
}
