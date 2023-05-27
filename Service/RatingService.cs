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
  
    public class RatingService
    {
        private UnitOfWork unitOfWork;
        private Rating Rating;

        public RatingService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public void Create(RatingViewModel RatingVM)
        {
            Rating = new Rating
            {
                Name = RatingVM.Name,
                No = RatingVM.No
            };

            unitOfWork.RatingRepository.Insert(Rating);
            unitOfWork.Save();
        }


        public void Update(RatingViewModel RatingVM)
        {
            Rating = new Rating
            {
                Id = RatingVM.Id,
                Name = RatingVM.Name,
                No=RatingVM.No
            };

            unitOfWork.RatingRepository.Update(Rating);
            unitOfWork.Save();
        }


        public List<RatingViewModel> GetAll()
        {
            var result = (from s in unitOfWork.RatingRepository.Get()
                          orderby s.Id descending
                          select new RatingViewModel
                          {
                              Id = s.Id,
                              Name = s.Name,
                              No=s.No
                          }).ToList();

            return result;
        }


        public RatingViewModel GetById(int id)
        {
            var result = (from s in unitOfWork.RatingRepository.Get()
                          where s.Id == id
                          select new RatingViewModel
                          {
                              Id = s.Id,
                              Name = s.Name,
                              No=s.No
                          }).SingleOrDefault();

            return result;
        }


    }
}
