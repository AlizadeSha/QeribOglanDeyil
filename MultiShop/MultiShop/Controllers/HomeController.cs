using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;
using MultiShop.Models;
using MultiShop.ViewModels;

namespace MultiShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            List<Slider> sliders = await _context.Sliders.OrderBy(s=>s.Order).ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();

            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                Categories = categories
            };
            return View(homeVM);

        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
