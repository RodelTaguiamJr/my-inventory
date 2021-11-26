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
   
    public class BusinessController : Controller
    {
        private readonly ApplicationDBContext _context;
        public BusinessController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Businesses.Include(p => p.BusinessOwnerID).ToList();

            return View(list);
        }
        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(Business record)
        {
            var business = new Business();
            var fkID = _context.Users.
                Where(c => c.Id == record.BusId).SingleOrDefault();

            business.BusId = fkID.Id;
            business.BusinessOwnerID = fkID;
            business.BOID = fkID.Id;
            business.Name = record.Name;
            business.Description = record.Description;
            business.Location = record.Location;
            business.SocialMedia = record.SocialMedia;
            business.Type = record.Type;


            _context.Businesses.Add(business);
            _context.SaveChanges();

            return RedirectToAction("Index", "Item");
        }
        public IActionResult Delete(string? id)
        {


            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Businesses.Where(p => p.BusId == id).SingleOrDefault();
            var user = _context.Users.Where(p => p.Id == product.BOID).SingleOrDefault();


            if (product == null)
            {
                return RedirectToAction("Index");
            }


            _context.Businesses.Remove(product);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
