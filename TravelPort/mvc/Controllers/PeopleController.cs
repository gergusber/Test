using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TravelPort.Domain.Models;
using TravelPort.Domain.Service;

namespace TravelPoint.Client.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _service;

        public PeopleController(IPeopleService service)
        {
            _service = service;
        }

        // GET: People
        public IActionResult Index()
        {
            return View(_service.GetAll().Result);
        }

        // GET: People/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = _service.GetById(id.Value).Result;

            if (people == null)
            {
                return NotFound();
            }

            return View(people);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,DNI,Phone")] People people)
        {
            if (ModelState.IsValid)
            {
               await _service.Add(people);
                return RedirectToAction(nameof(Index));
            }
            return View(people);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var people = await _service.GetById(id.Value);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,DNI,Phone")] People people)
        {
            if (id != people.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(people);
                 }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleExists(people.Id))
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
            return View(people);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var people = _service.GetById(id.Value).Result;
             if (people == null)
            {
                return NotFound();
            }

            return View(people);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Remove(id);

           return RedirectToAction(nameof(Index));
        }

        private bool PeopleExists(int id)
        {
            return _service.GetById(id) != null;
        }
    }
}