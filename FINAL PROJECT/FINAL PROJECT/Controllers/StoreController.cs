using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FINAL_PROJECT.Data;
using FINAL_PROJECT.Models;

namespace FINAL_PROJECT.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDBContext _context;
        public StoreController(ApplicationDBContext context)
        {
            _context = context;

        }

        public IActionResult Index(string? c)
        {
            var products = _context.Items
                .Include(p => p.Business)
                .ToList();

            if (c != null)
            {
                products = products.Where(p => p.CatBusiness == c)
                    .ToList();
            }

            var categories = _context.Businesses
                .OrderBy(c => c.Name)
                .ToList();

            var record = new StoreViewModel()
            {
                ItemList = products,
                BusinessList = categories
            };

            return View(record);
        }
    }
}
