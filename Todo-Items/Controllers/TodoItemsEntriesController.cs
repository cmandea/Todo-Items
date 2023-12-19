using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todo_Items.Data;
using Todo_Items.Models;

namespace Todo_Items.Controllers
{
    public class TodoItemsEntriesController : Controller
    {
        private readonly DataBaseContext _context;

        public TodoItemsEntriesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: TodoItemsEntries
        public async Task<IActionResult> Index()
        {
            return _context.TodoItemsEntry != null ?
                        View(await _context.TodoItemsEntry.ToListAsync()) :
                        Problem("Entity set 'DataBaseContext.TodoItemsEntry'  is null.");
        }

        // GET: TodoItemsEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TodoItemsEntry == null)
            {
                return NotFound();
            }

            var todoItemsEntry = await _context.TodoItemsEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoItemsEntry == null)
            {
                return NotFound();
            }

            return View(todoItemsEntry);
        }

        // GET: TodoItemsEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoItemsEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameTodoItem,DateStop,StatusTodoItems")] TodoItemsEntry todoItemsEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoItemsEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoItemsEntry);
        }

        // GET: TodoItemsEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TodoItemsEntry == null)
            {
                return NotFound();
            }

            var todoItemsEntry = await _context.TodoItemsEntry.FindAsync(id);
            if (todoItemsEntry == null)
            {
                return NotFound();
            }
            return View(todoItemsEntry);
        }

        // POST: TodoItemsEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameTodoItem,DateStop,StatusTodoItems")] TodoItemsEntry todoItemsEntry)
        {
            if (id != todoItemsEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoItemsEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemsEntryExists(todoItemsEntry.Id))
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
            return View(todoItemsEntry);
        }

        // GET: TodoItemsEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TodoItemsEntry == null)
            {
                return NotFound();
            }

            var todoItemsEntry = await _context.TodoItemsEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoItemsEntry == null)
            {
                return NotFound();
            }

            return View(todoItemsEntry);
        }

        // POST: TodoItemsEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TodoItemsEntry == null)
            {
                return Problem("Entity set 'DataBaseContext.TodoItemsEntry'  is null.");
            }
            var todoItemsEntry = await _context.TodoItemsEntry.FindAsync(id);
            if (todoItemsEntry != null)
            {
                _context.TodoItemsEntry.Remove(todoItemsEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoItemsEntryExists(int id)
        {
            return (_context.TodoItemsEntry?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
