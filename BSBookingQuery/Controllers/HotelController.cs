using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;

namespace BSBookingQuery.Controllers
{
    public class HotelController : Controller
    {
        private HotelService hotelService;
        private IWebHostEnvironment _he;
        public HotelController(HotelService hotelService, IWebHostEnvironment he)
        {
            this.hotelService = hotelService;
            _he = he;
        }

        public IActionResult Index()
        {
            var data = hotelService.GetAll();

            if (data == null) return NotFound();
            return View(data);
        }
        public IActionResult Get()
        {
            var data = hotelService.GetAll();

            if (data == null) return NotFound();

            return Ok(data);
        }


        public IActionResult Details(int id)
        {
            var data = hotelService.GetById(id);

            if (data == null) return NotFound();

            return View(data);
        }

        public IActionResult Create()
        {
            ViewData["locationId"] = new SelectList(hotelService.LocationDropDown(), "Value", "Text");
            ViewData["ratingId"] = new SelectList(hotelService.RatingDropDown(), "Value", "Text");
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelViewModel model, IFormFile image)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            if (image != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                image.CopyTo(new FileStream(name, FileMode.Create));
                model.Image = "Images/" + image.FileName;
            }
            if (image == null)
            {
                model.Image = "Images/noimage.png";
            }
            hotelService.Create(model);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var data = hotelService.GetById(id);
            ViewData["locationId"] = new SelectList(hotelService.LocationDropDown(), "Value", "Text");
            ViewData["ratingId"] = new SelectList(hotelService.RatingDropDown(), "Value", "Text");

            if (data == null) return NotFound();

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(HotelViewModel model, IFormFile image)
        {
            if (image != null)
            {
                var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                image.CopyTo(new FileStream(name, FileMode.Create));
                model.Image = "Images/" + image.FileName;
            }
            if (image == null)
            {
                model.Image = "Images/noimage.png";
            }

            hotelService.Update(model);
            return RedirectToAction("Index");
        }
    }
}
