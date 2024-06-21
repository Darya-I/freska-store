using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Store_microservice.Data;
using Store_microservice.Models;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Store_microservice.Controllers
{
    public class CatalogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CatalogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Products.Include(i => i.Subcategory)
                                          .Include(i => i.Gender)
                                          .Include(i => i.Images)
                                          .ToList();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            var json = System.Text.Json.JsonSerializer.Serialize(items, options);
            return Content(json, "application/json");
            }


            //public IActionResult Index()
            //{
            //    var items = _context.Products.Include(i => i.Subcategory)
            //                                  .Include(i => i.Gender)
            //                                  .Include(i => i.Images)
            //                                  .ToList();
            //    return Json(items);
            //}


            public async Task<IActionResult> Recommendations()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index");
            }

            using var client = new HttpClient();
            var response = await client.GetAsync($"http://api-gateway/api/recommendations/{userId}");
            response.EnsureSuccessStatusCode();

            var recommendations = await response.Content.ReadAsStringAsync();
            var recommendedProductIds = JsonConvert.DeserializeObject<List<int>>(recommendations);

            var recommendedProducts = _context.Products
                                              .Include(i => i.Subcategory)
                                              .Include(i => i.Gender)
                                              .Include(i => i.Images)
                                              .Where(p => recommendedProductIds.Contains(p.ProductId))
                                              .ToList();

            return View(recommendedProducts);
        }

    }
}
