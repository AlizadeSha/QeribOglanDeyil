using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;
using MultiShop.Models;
using MultiShop.ViewModels.Categories;

namespace MultiShop.Areas.admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.Where(x => x.IsDeleted == false).Select(s => new GetCategoryVM
            {
                Id = s.Id,
                CategoryName=s.Name,

            }
            ).ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVm vm)

        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Category category = new Category
            {
                Name = vm.Name,
                CreatedAt = DateTime.Now,
                CreatedBy="Shahin",
                IsDeleted = false,
                   
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
