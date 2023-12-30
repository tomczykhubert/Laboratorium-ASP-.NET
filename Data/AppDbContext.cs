using Data.Entities;
using Data.Entities.Post;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity > Organizations { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

        private string Path { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Path = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={Path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "adam",
                NormalizedUserName = "ADAM",
                Email = "adam@wsei.edu.pl",
                NormalizedEmail = "ADAM@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Hubert",
                NormalizedUserName = "HUBERT",
                Email = "hubert@wsei.edu.pl",
                NormalizedEmail = "HUBERT@WSEI.EDU.PL",
                EmailConfirmed = true,
            };
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();

            admin.PasswordHash = passwordHasher.HashPassword(admin, "1234Abcd!");
            user.PasswordHash = passwordHasher.HashPassword(user, "1234Abcd!");

            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);

            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN",
            };

            adminRole.ConcurrencyStamp = adminRole.Id;
            modelBuilder.Entity<IdentityRole>().HasData(adminRole);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminRole.Id,
                    UserId = admin.Id,
                });

            modelBuilder.Entity<ContactEntity>().HasOne(c => c.Organization).WithMany(o => o.Contacts).HasForeignKey(c => c.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>().HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    Name = "WSEI",
                    Description = "Uczelnia wyższa"
                },
                new OrganizationEntity()
                {
                Id = 102,
                    Name = "Comarch",
                    Description = "Przedsiębiorstwo IT"
                }
                );
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity()
                {
                    ContactId = 1,
                    Name = "Adam",
                    Email = "adam@wsei.edu.pl",
                    Phone = "1234567890",
                    Birth = DateTime.Parse("1980-02-10"),
                    OrganizationId = 101,
                },
                new ContactEntity()
                {
                    ContactId = 2,
                    Name = "Ewa",
                    Email = "ewa@wsei.edu.pl",
                    Phone = "0987654321",
                    Birth = DateTime.Parse("1970-10-22"),
                    OrganizationId = 102,
                }
                );
            modelBuilder.Entity<OrganizationEntity>().OwnsOne(o => o.Address).HasData(
                new
                {
                    OrganizationEntityId = 101,
                    City = "Kraków",
                    Street = "św. Filipa 17",
                    PostalCode = "31-150",
                },
                new
                {
                    OrganizationEntityId = 102,
                    City = "Kraków",
                    Street = "Rozwoju 1/4",
                    PostalCode = "36-160",
                }
                );
            modelBuilder.Entity<PostEntity>().HasOne(c => c.Tag).WithMany(o => o.Posts).HasForeignKey(c => c.TagId);
            modelBuilder.Entity<CommentEntity>().HasOne(c => c.Post).WithMany(o => o.Comments).HasForeignKey(c => c.PostId);

            modelBuilder.Entity<TagEntity>().HasData(
                new
                {
                    TagId = 1,
                    TagName = "Polityka",

                },
                new
                {
                    TagId = 2,
                    TagName = "Sport",

                },
                new
                {
                    TagId = 3,
                    TagName = "Nauka",

                },
                new
                {
                    TagId = 4,
                    TagName = "Motoryzacja",

                },
                new
                {
                    TagId = 5,
                    TagName = "Gry",

                }
                );
            modelBuilder.Entity<CommentEntity>().HasData(
                new
                {
                    CommentId = 1,
                    PostId = 1,
                    Author = "Karolina",
                    Content = "Już nie mogę się doczekać!",
                    PublicationDate = DateTime.Now,
                },
                new
                {
                    CommentId = 2,
                    PostId = 2,
                    Author = "Milena",
                    Content = "Słabo im szło w tym sezonie.",
                    PublicationDate = DateTime.Now,
                },
                new
                {
                    CommentId = 3,
                    PostId = 3,
                    Author = "Andrzej",
                    Content = "Tak, doszło do trzykrotnego zwiększenia jej wielkości.",
                    PublicationDate = DateTime.Now,
                },
                new
                {
                    CommentId = 4,
                    PostId = 4,
                    Author = "Karol",
                    Content = "Oczywiście, że Toyota!",
                    PublicationDate = DateTime.Now,
                },
                new
                {
                    CommentId = 5,
                    PostId = 5,
                    Author = "Sam",
                    Content = "Najgorsze jest to, że na premierę na PC poczekamy pewnie do 2027.",
                    PublicationDate = DateTime.Now,
                }
                );

            modelBuilder.Entity<PostEntity>().HasData(
                new
                {
                    PostId = 1,
                    Author = "Janek",
                    TagId = 1,
                    Content = "W 2025 wybory na prezydenta!",
                    PublicationDate = DateTime.Now
                },
                new
                {
                    PostId = 2,
                    Author = "Grzegorz",
                    TagId = 2,
                    Content = "Real Madryt odpadł z ligi mistrzów.",
                    PublicationDate = DateTime.Now
                },
                new
                {
                    PostId = 3,
                    Author = "Ania",
                    TagId = 3,
                    Content = "Wiatr słoneczny zniekształcił atmosfere marsa!",
                    PublicationDate = DateTime.Now
                },
                new
                {
                    PostId = 4,
                    Author = "Kasia",
                    TagId = 4,
                    Content = "Toyota Supra vs Nissan Skyline R34?",
                    PublicationDate = DateTime.Now,

                },
                new
                {
                    PostId = 5,
                    Author = "Alex",
                    TagId = 5,
                    Content = "Nie mogę się doczekać premiery GTA VI!",
                    PublicationDate = DateTime.Now,
                }
                );
        }
        
    }
}