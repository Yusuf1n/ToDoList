#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcToDoList.Data;
using MvcToDoList.Models;

namespace MvcToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly MvcToDoListContext _context;

        public ToDoListController(MvcToDoListContext context)
        {
            _context = context;
        }

        // GET: ToDoList
        public async Task<IActionResult> Index(string toDoListPriority ,string toDoListStatus, string searchString)
        {
            // Use LINQ to get list of statuses.
            IQueryable<string> statusQuery = from t in _context.ToDoList
                                            orderby t.Status
                                            select t.Status;

            // Use LINQ to get list of statuses.
            IQueryable<string> priorityQuery = from t in _context.ToDoList
                                               orderby t.Priority
                                               select t.Priority;

            var toDoList = from t in _context.ToDoList
                         select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                toDoList = toDoList.Where(s => s.Task!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(toDoListStatus))
            {
                toDoList = toDoList.Where(x => x.Status == toDoListStatus);
            }

            if (!string.IsNullOrEmpty(toDoListPriority))
            {
                toDoList = toDoList.Where(x => x.Priority == toDoListPriority);
            }

            var toDoListStatusPriorityVM = new ToDoListStatusPriorityViewModel
            {
                Priorities = new SelectList(await priorityQuery.Distinct().ToListAsync()),
                Statuses = new SelectList(await statusQuery.Distinct().ToListAsync()),
                ToDoLists = await toDoList.ToListAsync()
            };

            return View(toDoListStatusPriorityVM);
        }

        // GET: ToDoList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return View(toDoList);
        }

        // GET: ToDoList/Create
        public IActionResult Create()
        {
            var model = new ToDoList();
            return View(model);
        }

        // POST: ToDoList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Task,Description,Status,Priority,Assgignee,Comments,Created,CompleteBy")] ToDoList toDoList)
        {
            if(toDoList.Task == toDoList.Description)
            {
                ModelState.AddModelError("Task", "The Task cannot exactly match the Description.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(toDoList);
                await _context.SaveChangesAsync();
                TempData["Success"] = "To Do created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(toDoList);
        }

        // GET: ToDoList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Task,Description,Status,Priority,Assgignee,Comments,Created,CompleteBy")] ToDoList toDoList)
        {
            if (id != toDoList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoList);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "To Do updated successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoListExists(toDoList.Id))
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
            return View(toDoList);
        }

        // GET: ToDoList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return View(toDoList);
        }

        // POST: ToDoList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoList = await _context.ToDoList.FindAsync(id);
            _context.ToDoList.Remove(toDoList);
            await _context.SaveChangesAsync();
            TempData["Success"] = "To Do deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoListExists(int id)
        {
            return _context.ToDoList.Any(e => e.Id == id);
        }
    }
}
