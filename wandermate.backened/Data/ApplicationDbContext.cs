using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wandermate.backened.Models;

namespace wandermate.backened.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<TravelPackages> TravelPackages { get; set; }

        public DbSet<Review> HotelReviews { get; set; }

        // public DbSet<Users> Users { get; set; }


        public DbSet<Booking> HotelBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure many-to-many 
            builder.Entity<Booking>()
                .HasOne(hb => hb.hotel) //it shows it has one relation with hotel whic include one hotelid
                .WithMany(h => h.HotelBookings)//it shows many relation with booking
                .HasForeignKey(hb => hb.HotelId)//it shows that hotelid as  foreignkey 
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Booking>()
                .HasOne(hb => hb.AppUser)
                .WithMany(u => u.HotelBookings)
                .HasForeignKey(hb => hb.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // builder.Entity<Users>()
            //    .HasIndex(u => u.Email)
            //    .IsUnique();


            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                 new IdentityRole{
                    Name="User",
                    NormalizedName="USER"
                },

            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }

}

