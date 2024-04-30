using CodeWithDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeWithDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext studentDb;

        public HomeController(StudentDbContext studentDb) {
            this.studentDb = studentDb;
        }

        public async Task<IActionResult> Index()
        { 
            var modelList = await studentDb.Students.ToListAsync();
            return View(modelList);
        }

        public IActionResult Create()
        {
            List<SelectListItem> selectList = new()
            {
                new SelectListItem { Text = "Male", Value = "Male" },
                new SelectListItem { Text = "Female", Value = "Female" }
            };
            ViewBag.Gender = selectList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if(ModelState.IsValid)
            {
               await studentDb.Students.AddAsync(student);
               await studentDb.SaveChangesAsync();
               TempData["insertSuccess"] = "Inserted...";
               return RedirectToAction("Index","Home");
            }
            return View(student);
        }  
        
        public async Task<IActionResult> Details(int? id)
        { 
            if(id == null || studentDb == null)
            {
                return NotFound();
            }
            var student = await studentDb.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentDb == null)
            {
                return NotFound();
            }
            var student = await studentDb.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            List<SelectListItem> selectList = new()
            {
                new SelectListItem { Text = "Male", Value = "Male" },
                new SelectListItem { Text = "Female", Value = "Female" }
            };
            ViewBag.Gender = selectList;

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if(id != student.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid) 
            {
                studentDb.Update(student);
                await studentDb.SaveChangesAsync();
                TempData["updateSuccess"] = "Update...";
                return RedirectToAction("Index", "Home");
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null || studentDb == null)
            {
                return NotFound();
            }
            var student = await studentDb.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost,ActionName("View")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var student = await studentDb.Students.FindAsync(id);
          
            if (student != null)
            {
                studentDb.Students.Remove(student);
                await studentDb.SaveChangesAsync();
                TempData["deleteSuccess"] = "Delete...";
                return RedirectToAction("Index","Home");
            }

            return View();
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
