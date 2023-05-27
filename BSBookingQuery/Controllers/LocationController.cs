using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace BSBookingQuery.Controllers
{
    public class LocationController : Controller
    {
       
        private LocationService locationService;
        public LocationController(LocationService locationService)
        {
            this.locationService = locationService;
        }

        public IActionResult Index()
        {
            var data = locationService.GetAll();

            if (data == null) return NotFound();
            return View(data);
        }
        public IActionResult Get()
        {
            var data = locationService.GetAll();

            if (data == null) return NotFound();

            return Ok(data);
        }

       
        public IActionResult Details(int id)
        {
            var data = locationService.GetById(id);

            if (data == null) return NotFound();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LocationViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

             locationService.Create(model);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var data = locationService.GetById(id);

            if (data == null) return NotFound();

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(LocationViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            locationService.Update(model);
            return RedirectToAction("Index");
        }
    }
}
