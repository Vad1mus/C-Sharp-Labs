using Lab08.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationContext _db;
        public HomeController(ApplicationContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Student student = await _db.Students.FirstOrDefaultAsync(p => p.StudentId == id);
                if (student != null)
                    return View(student);
            }
            return NotFound();  
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Student student = await _db.Students.FirstOrDefaultAsync(p => p.StudentId == id);
                if (student != null)
                    return View(student);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Student student = await _db.Students.FirstOrDefaultAsync(p => p.StudentId == id);
                if (student != null)
                {
                    _db.Students.Remove(student);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Students.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
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
