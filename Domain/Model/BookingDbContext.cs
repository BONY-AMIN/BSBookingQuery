using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Model
{
    public partial class BookingDbContext : IdentityDbContext
    {
        public BookingDbContext()
        {

        }

        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }



    }
}
