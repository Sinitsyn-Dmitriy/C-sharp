using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodolistApp.Models;

namespace TodolistApp.Controllers
{
    public class TodolistitemsController : Controller
    {
        private readonly TodolistAppContext _context;

        public TodolistitemsController(TodolistAppContext context)
        {
            _context = context;    
        }

        /*  // GET: Todolistitems
          public async Task<IActionResult> Index(string searchString)
          {
              var todolist = from m in _context.Todolistitem
                             select m;

              if (!String.IsNullOrEmpty(searchString))
              {
                  todolist = todolist.Where(s => s.Title.Contains(searchString));
              }

              return View(await todolist.ToListAsync());
          }

      */


        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string todolistCategory, string searchString)
        {

            // Use LINQ to get list of categories.
            IQueryable<string> categoryQuery = from m in _context.Todolistitem
                                               orderby m.Category
                                               select m.Category;

            var todolist = from m in _context.Todolistitem
                           select m;



            if (!String.IsNullOrEmpty(searchString))
            {
                todolist = todolist.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(todolistCategory))
            {
                todolist = todolist.Where(x => x.Category == todolistCategory);
            }

            var todolistCategoryVM = new TodolistCategoryViewModel();
            todolistCategoryVM.categories = new SelectList(await categoryQuery.Distinct().ToListAsync());
            todolistCategoryVM.todolist = await todolist.ToListAsync();

            return View(todolistCategoryVM);

        }




        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


        // GET: Todolistitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todolistitem = await _context.Todolistitem
                .SingleOrDefaultAsync(m => m.ID == id);
            if (todolistitem == null)
            {
                return NotFound();
            }

            return View(todolistitem);
        }

        // GET: Todolistitems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todolistitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Category,Date,Status,TimeTaken")] Todolistitem todolistitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todolistitem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(todolistitem);
        }

        // GET: Todolistitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todolistitem = await _context.Todolistitem.SingleOrDefaultAsync(m => m.ID == id);
            if (todolistitem == null)
            {
                return NotFound();
            }
            return View(todolistitem);
        }

        // POST: Todolistitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Category,Date,Status,TimeTaken")] Todolistitem todolistitem)
        {
            if (id != todolistitem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todolistitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodolistitemExists(todolistitem.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(todolistitem);
        }

        // GET: Todolistitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todolistitem = await _context.Todolistitem
                .SingleOrDefaultAsync(m => m.ID == id);
            if (todolistitem == null)
            {
                return NotFound();
            }

            return View(todolistitem);
        }

        // POST: Todolistitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todolistitem = await _context.Todolistitem.SingleOrDefaultAsync(m => m.ID == id);
            _context.Todolistitem.Remove(todolistitem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TodolistitemExists(int id)
        {
            return _context.Todolistitem.Any(e => e.ID == id);
        }
    }
}
