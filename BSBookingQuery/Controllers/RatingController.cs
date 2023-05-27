using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace BSBookingQuery.Controllers
{
    public class RatingController : Controller
    {
        private RatingService ratingService;
        public RatingController(RatingService ratingService)
        {
            this.ratingService = ratingService;
        }

        public IActionResult Index()
        {
            var data = ratingService.GetAll();

            if (data == null) return NotFound();
            return View(data);
        }
        public IActionResult Get()
        {
            var data = ratingService.GetAll();

            if (data == null) return NotFound();

            return Ok(data);
        }


        public IActionResult Details(int id)
        {
            var data = ratingService.GetById(id);

            if (data == null) return NotFound();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RatingViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            ratingService.Create(model);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var data = ratingService.GetById(id);

            if (data == null) return NotFound();

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(RatingViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            ratingService.Update(model);
            return RedirectToAction("Index");
        }
    }
}
