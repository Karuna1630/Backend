using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wandermate.backened.Models;

namespace wandermate.backened.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<TravelPackages> TravelPackages { get; set; }

        public DbSet<Review> HotelReviews { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}