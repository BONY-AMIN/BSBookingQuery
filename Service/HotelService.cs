using Domain.Model;
using Domain.Repositories;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HotelService
    {
        private UnitOfWork unitOfWork;
        private Hotel hotel;

        public HotelService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public void Create(HotelViewModel HotelVM)
        {
            hotel = new Hotel
            {
                Name = HotelVM.Name,
                HotelType=HotelVM.HotelType,
                Price=HotelVM.Price,
                Details=HotelVM.Details,
                Address=HotelVM.Address,
                NearestLoc1=HotelVM.NearestLoc1,
                NearestLoc2=HotelVM.NearestLoc2,
                LocationId=HotelVM.LocationId,
                RatingId=HotelVM.RatingId,
                Image=HotelVM.Image
              
            };

            unitOfWork.HotelRepository.Insert(hotel);
            unitOfWork.Save();
        }

        public void CreateComment(HotelViewModel HotelVM)
        {
            var comment = new Comment
            {
                CommentorName = HotelVM.CommentorName,
                Title = HotelVM.Title,
                Comments = HotelVM.Comments,
                HotelId = HotelVM.Id,
               

            };

            unitOfWork.CommentRepository.Insert(comment);
            unitOfWork.Save();
        }
        public void Update(HotelViewModel HotelVM)
        {
            hotel = new Hotel
            {
                Id = HotelVM.Id,
                Name = HotelVM.Name,
                HotelType = HotelVM.HotelType,
                Price = HotelVM.Price,
                Details = HotelVM.Details,
                Address = HotelVM.Address,
                NearestLoc1 = HotelVM.NearestLoc1,
                NearestLoc2 = HotelVM.NearestLoc2,
                LocationId = HotelVM.LocationId,
                RatingId = HotelVM.RatingId,
                Image = HotelVM.Image
            };

            unitOfWork.HotelRepository.Update(hotel);
            unitOfWork.Save();
        }


        public List<HotelViewModel> GetAll()
        {
            var result = (from s in unitOfWork.HotelRepository.Get()
                          join l in unitOfWork.LocationRepository.Get() on s.LocationId equals l.Id
                          join r in unitOfWork.RatingRepository.Get() on s.RatingId equals r.Id
                          orderby s.Id descending
                          select new HotelViewModel
                          {
                              Id = s.Id,
                              Name = s.Name,
                              HotelType = s.HotelType,
                              Price = s.Price,
                              Details = s.Details,
                              Address = s.Address,
                              NearestLoc1 = s.NearestLoc1,
                              NearestLoc2 = s.NearestLoc2,
                              LocationId = s.LocationId,
                              LocationNm=l.Name,
                              RatingId = s.RatingId,
                              RatingNm=r.Name,
                              Image = s.Image
                          }).ToList();

            return result;
        }

        public List<HotelViewModel> GetAllBySearch(string name,string location,int lowrating,int highrating)
        {
            var result = (from s in unitOfWork.HotelRepository.Get()
                          join l in unitOfWork.LocationRepository.Get() on s.LocationId equals l.Id
                          join r in unitOfWork.RatingRepository.Get() on s.RatingId equals r.Id
                          where (name == null ? s.Name == s.Name : s.Name.ToLower() == name.ToLower())
                          && (location == null ? l.Name == l.Name : l.Name.ToLower() == location.ToLower())
                          && (lowrating == 0 ? r.No == r.No : r.No >= lowrating)
                          && (highrating == 0 ? r.No == r.No : r.No <= highrating)
                         
                          orderby s.Id descending
                          select new HotelViewModel
                          {
                              Id = s.Id,
                              Name = s.Name,
                              HotelType = s.HotelType,
                              Price = s.Price,
                              Details = s.Details,
                              Address = s.Address,
                              NearestLoc1 = s.NearestLoc1,
                              NearestLoc2 = s.NearestLoc2,
                              LocationId = s.LocationId,
                              LocationNm = l.Name,
                              RatingId = s.RatingId,
                              RatingNm = r.Name,
                              Image = s.Image
                          }).ToList();

            return result;
        }


        public HotelViewModel GetById(int id)
        {
            var result = (from s in unitOfWork.HotelRepository.Get()
                          join l in unitOfWork.LocationRepository.Get() on s.LocationId equals l.Id
                          join r in unitOfWork.RatingRepository.Get() on s.RatingId equals r.Id
                          where s.Id == id
                          select new HotelViewModel
                          {
                              Id = s.Id,
                              Name = s.Name,
                              HotelType = s.HotelType,
                              Price = s.Price,
                              Details = s.Details,
                              Address = s.Address,
                              NearestLoc1 = s.NearestLoc1,
                              NearestLoc2 = s.NearestLoc2,
                              LocationId = s.LocationId,
                              LocationNm=l.Name,
                              RatingId = s.RatingId,
                              RatingNm=r.Name,
                              Image = s.Image
                          }).SingleOrDefault();

            return result;
        }

        public HotelViewModel GetDetailsWithComment(int id)
        {
            var result = (from s in unitOfWork.HotelRepository.Get()
                          join l in unitOfWork.LocationRepository.Get() on s.LocationId equals l.Id
                          join r in unitOfWork.RatingRepository.Get() on s.RatingId equals r.Id
                          where s.Id == id
                          select new HotelViewModel
                          {
                              Id = s.Id,
                              Name = s.Name,
                              HotelType = s.HotelType,
                              Price = s.Price,
                              Details = s.Details,
                              Address = s.Address,
                              NearestLoc1 = s.NearestLoc1,
                              NearestLoc2 = s.NearestLoc2,
                              LocationId = s.LocationId,
                              LocationNm = l.Name,
                              RatingId = s.RatingId,
                              RatingNm = r.Name,
                              Image = s.Image
                          }).SingleOrDefault();

            if (result != null)
            {
                
                result.commentLists =(from s in unitOfWork.CommentRepository.Get()
                                   where s.HotelId==id
                                                 orderby s.Id descending
                                                 select new CommentList
                                                 {
                                                     Title = s.Title,
                                                     CommentorName = s.CommentorName,
                                                     Comments = s.Comments
                                                 }).ToList();

            }

            return result;
        }
        public List<DropDownViewModel> LocationDropDown()
        {
            var result = (from s in unitOfWork.LocationRepository.Get()
                          orderby s.Id descending
                          select new DropDownViewModel
                          {
                              Value = s.Id,
                              Text = s.Name
                          }).ToList();

            return result;
        }

        public List<DropDownViewModel> RatingDropDown()
        {
            var result = (from s in unitOfWork.RatingRepository.Get()
                          orderby s.Id descending
                          select new DropDownViewModel
                          {
                              Value = s.Id,
                              Text = s.Name
                            
                          }).ToList();

            return result;
        }

    }
}
