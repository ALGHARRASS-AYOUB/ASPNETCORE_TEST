using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EXERCICE4.Models;
using EXERCICE4.Services;

namespace EXERCICE4.Controllers
{
    public class EtudiantsController : Controller
    {
        private readonly IEtudiantService _service;
        private readonly StudentsDbContext _studentsDbContext=new StudentsDbContext();

        public EtudiantsController(IEtudiantService service)
        {
            _service = service;
        }

        // GET: Etudiants
        public async Task<IActionResult> Index()
        {
            IEnumerable<Etudiant> students = _service.FindAll();
            
            return   View(students); 
        }

        // GET: Etudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Etudiant etudiant = _service.GetEtudiantById(id);
            if(etudiant == null)
                return NotFound();  
            return View(etudiant);
        }

        // GET: Etudiants/Create
        public IActionResult Create()
        {
            ViewData["FiliereId"] = new SelectList(_studentsDbContext.Filieres, "Id", "Name");
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,FiliereId")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                /*  _studentsDbContext.Add(etudiant);
                  await _studentsDbContext.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));*/
                _service.Save(etudiant);
            }
            ViewData["FiliereId"] = new SelectList(_studentsDbContext.Filieres, "Id", "Id", etudiant.FiliereId);
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _studentsDbContext.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _studentsDbContext.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            ViewData["FiliereId"] = new SelectList(_studentsDbContext.Filieres, "Id", "Id", etudiant.FiliereId);
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,FiliereId")] Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentsDbContext.Update(etudiant);
                    await _studentsDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FiliereId"] = new SelectList(_studentsDbContext.Filieres, "Id", "Id", etudiant.FiliereId);
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _studentsDbContext.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _studentsDbContext.Etudiants
                .Include(e => e.Filiere)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_studentsDbContext.Etudiants == null)
            {
                return Problem("Entity set 'StudentsDbContext.Etudiants'  is null.");
            }
            var etudiant = await _studentsDbContext.Etudiants.FindAsync(id);
            if (etudiant != null)
            {
                _studentsDbContext.Etudiants.Remove(etudiant);
            }
            
            await _studentsDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(int id)
        {
          return _studentsDbContext.Etudiants.Any(e => e.Id == id);
        }
    }
}
