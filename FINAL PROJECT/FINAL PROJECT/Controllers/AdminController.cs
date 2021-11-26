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
    public class AdminController : Controller
    {
        private readonly ApplicationDBContext _context;
        public AdminController(ApplicationDBContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var list = _context.Businesses.Include(p => p.BusinessOwnerID).ToList();

            return View(list);
        }
    }
}
