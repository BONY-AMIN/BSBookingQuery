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
    public class LocationService
    {
        private UnitOfWork unitOfWork;
        private Location location;

        public LocationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

       
        public void Create(LocationViewModel LocationVM)
        {
            location = new Location
            {
                Name = LocationVM.Name
            };

            unitOfWork.LocationRepository.Insert(location);
            unitOfWork.Save();
        }

       
        public void Update(LocationViewModel LocationVM)
        {
            location = new Location
            {
                Id = LocationVM.Id,
                Name = LocationVM.Name
            };

            unitOfWork.LocationRepository.Update(location);
            unitOfWork.Save();
        }

       
        public List<LocationViewModel> GetAll()
        {
            var result = (from s in unitOfWork.LocationRepository.Get()
                          orderby s.Id descending
                          select new LocationViewModel
                          {
                              Id = s.Id,
                              Name = s.Name
                          }).ToList();

            return result;
        }


        public LocationViewModel GetById(int id)
        {
            var result = (from s in unitOfWork.LocationRepository.Get()
                          where s.Id == id
                          select new LocationViewModel
                          {
                              Id = s.Id,
                              Name = s.Name 
                          }).SingleOrDefault();

            return result;
        }

       
    }
}
