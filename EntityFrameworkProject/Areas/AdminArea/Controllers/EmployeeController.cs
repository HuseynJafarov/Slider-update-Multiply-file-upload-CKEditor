using EntityFrameworkProject.Data;
using EntityFrameworkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _context.Employees.Where(m => !m.IsDeleted).AsNoTracking().OrderByDescending(m => m.Id).ToListAsync();
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetStatus(int id)
        {
            Employee employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            if (employee is null) return NotFound();

            if (employee.IsActive)
            {
                employee.IsActive = false;
            }
            else
            {
                employee.IsActive = true;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            Employee employee = await _context.Employees.FindAsync(id);

            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                bool isExist = await _context.Employees.AnyAsync(m => m.FullName.Trim() == employee.FullName.Trim() && m.Age == employee.Age
                && m.Position == employee.Position && m.IsActive == employee.IsActive);
                if (isExist)
                {
                    ModelState.AddModelError("Name And Url", "Category already exist");
                    return View();
                }

                await _context.Employees.AddAsync(employee);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            employee.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null) return BadRequest();

                Employee employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

                if (employee is null) return NotFound();

                return View(employee);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }

                Employee dbEmplooyee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

                if (dbEmplooyee is null) return BadRequest();

                if (dbEmplooyee.FullName.Trim().ToLower() == employee.FullName.Trim().ToLower() && dbEmplooyee.Age == employee.Age &&
                    dbEmplooyee.Position.Trim().ToLower() == employee.Position.Trim().ToLower() && dbEmplooyee.IsActive == employee.IsActive)
                {
                    return RedirectToAction(nameof(Index));
                }

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View(); throw;
            }
        }

    }
}
