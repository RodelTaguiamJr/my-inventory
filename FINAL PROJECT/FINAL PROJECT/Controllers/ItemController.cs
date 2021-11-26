using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FINAL_PROJECT.Data;
using FINAL_PROJECT.Models;

using Microsoft.AspNetCore.Http;
using System.IO;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace FINAL_PROJECT.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDBContext _context;
        public ItemController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Items.Include(p => p.Business).ToList();


            return View(list);
        }
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item record, IFormFile imagePath)
        {
            var selectedCategory = _context.Businesses.Where(
                c => c.BusId == record.CatBusiness).SingleOrDefault();

            

            var product = new Item();

            product.Name = record.Name;
            product.Code = record.Code;
            product.ImagePath = record.ImagePath;
            product.Description = record.Description;
            product.Price = record.Price;
            product.Available = record.Available;
            product.DateAdded = DateTime.Now;
            product.Business = selectedCategory;
            product.CatBusiness = record.CatBusiness;

            if (imagePath != null)
            {
                if (imagePath.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/items", imagePath.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imagePath.CopyTo(stream);
                    }
                    product.ImagePath = imagePath.FileName;
                }
            }



            _context.Items.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var item = _context.Items.Where(i => i.ItemId == id).SingleOrDefault();

            if (item == null)
            {
                return RedirectToAction("Index");
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Items.Where(p => p.ItemId == id).SingleOrDefault();

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Item record)
        {


            var product = _context.Items.Where(p => p.ItemId == id).SingleOrDefault();

            var selectedCategory = _context.Businesses.Where(
                c => c.BusId == record.CatBusiness).SingleOrDefault();

            product.Name = record.Name;
            product.Code = record.Code;
            product.Description = record.Description;
            product.Price = record.Price;
            product.Available = record.Available;
            product.DateModified = DateTime.Now;


            _context.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
