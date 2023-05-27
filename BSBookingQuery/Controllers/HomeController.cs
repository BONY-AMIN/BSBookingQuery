using BSBookingQuery.Models;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics;

namespace BSBookingQuery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HotelService hotelService;
        public HomeController(ILogger<HomeController> logger, HotelService hotelService)
        {
            _logger = logger;
            this.hotelService = hotelService;
        }

        public IActionResult Index()
        {
            var data = hotelService.GetAll();
            return View(data);
        }
        [HttpPost]
        public IActionResult Index(string name=null,string location=null,int lowrating=0,int highrating=0)
        {
            var data = hotelService.GetAllBySearch(name,location,lowrating,highrating);
            return View(data);
        }
        public IActionResult HotelDetails(int id)
        {
            var data = hotelService.GetDetailsWithComment(id);

            if (data == null) return NotFound();

            return View(data);
        }
        [HttpPost]
        public IActionResult HotelDetails(HotelViewModel model)
        {
                       
            hotelService.CreateComment(model);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}