using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UnitOfWork
    {
        private BookingDbContext db;

        public UnitOfWork(BookingDbContext db)
        {
            this.db = db;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private IRepository<Location> locationRepo;
        public IRepository<Location> LocationRepository
        {
            get
            {
                if (this.locationRepo == null)
                {
                    this.locationRepo = new Repository<Location>(db);
                }
                return locationRepo;
            }
        }
        private IRepository<Rating> ratingRepo;
        public IRepository<Rating> RatingRepository
        {
            get
            {
                if (this.ratingRepo == null)
                {
                    this.ratingRepo = new Repository<Rating>(db);
                }
                return ratingRepo;
            }
        }
        private IRepository<Comment> commentRepo;
        public IRepository<Comment> CommentRepository
        {
            get
            {
                if (this.commentRepo == null)
                {
                    this.commentRepo = new Repository<Comment>(db);
                }
                return commentRepo;
            }
        }

        private IRepository<Hotel> hotelRepo;
        public IRepository<Hotel> HotelRepository
        {
            get
            {
                if (this.hotelRepo == null)
                {
                    this.hotelRepo = new Repository<Hotel>(db);
                }
                return hotelRepo;
            }
        }
    }
}
