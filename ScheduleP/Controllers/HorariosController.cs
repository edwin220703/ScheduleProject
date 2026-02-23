using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleP.Models;

namespace ScheduleP.Controllers
{
    public class HorariosController : Controller
    {
        private readonly ScheduleDbContext _context;

        public HorariosController(ScheduleDbContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var scheduleDbContext = _context.Horarios.Include(h => h.IdAsignaturaNavigation).Include(h => h.IdAulaNavigation).Include(h => h.IdDocenteNavigation).Include(h => h.IdGrupoNavigation);
            return View(await scheduleDbContext.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.IdAsignaturaNavigation)
                .Include(h => h.IdAulaNavigation)
                .Include(h => h.IdDocenteNavigation)
                .Include(h => h.IdGrupoNavigation)
                .FirstOrDefaultAsync(m => m.IdHorario == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura");
            ViewData["IdAula"] = new SelectList(_context.Aulas, "IdAula", "IdAula");
            ViewData["IdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente");
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHorario,IdDocente,IdAsignatura,IdAula,IdGrupo,DiaSemana,HoraInicio,HoraFin")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura", horario.IdAsignatura);
            ViewData["IdAula"] = new SelectList(_context.Aulas, "IdAula", "IdAula", horario.IdAula);
            ViewData["IdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente", horario.IdDocente);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo", horario.IdGrupo);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura", horario.IdAsignatura);
            ViewData["IdAula"] = new SelectList(_context.Aulas, "IdAula", "IdAula", horario.IdAula);
            ViewData["IdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente", horario.IdDocente);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo", horario.IdGrupo);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHorario,IdDocente,IdAsignatura,IdAula,IdGrupo,DiaSemana,HoraInicio,HoraFin")] Horario horario)
        {
            if (id != horario.IdHorario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.IdHorario))
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
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura", horario.IdAsignatura);
            ViewData["IdAula"] = new SelectList(_context.Aulas, "IdAula", "IdAula", horario.IdAula);
            ViewData["IdDocente"] = new SelectList(_context.Docentes, "IdDocente", "IdDocente", horario.IdDocente);
            ViewData["IdGrupo"] = new SelectList(_context.Grupos, "IdGrupo", "IdGrupo", horario.IdGrupo);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.IdAsignaturaNavigation)
                .Include(h => h.IdAulaNavigation)
                .Include(h => h.IdDocenteNavigation)
                .Include(h => h.IdGrupoNavigation)
                .FirstOrDefaultAsync(m => m.IdHorario == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            if (horario != null)
            {
                _context.Horarios.Remove(horario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
            return _context.Horarios.Any(e => e.IdHorario == id);
        }
    }
}
