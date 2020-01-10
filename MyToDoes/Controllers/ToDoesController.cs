using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyToDoes.Data;
using MyToDoes.Models;

namespace MyToDoes.Controllers
{
    public class ToDoesController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ToDoes
        public IActionResult Index()
        {
            return View();
        }

       private IEnumerable<ToDo> GetMyToDoes()
        {
            IEnumerable<ToDo> myToDoes = _context.ToDoes.ToList();

            return myToDoes;
        }

        public IActionResult BuildTable()
        {
            return PartialView("_ToDoTable", GetMyToDoes());
        }
   

     
        // POST: ToDoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Date,IsDone")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDo);
                await _context.SaveChangesAsync();
            }
            return PartialView("_ToDoTable", GetMyToDoes());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, bool value)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDoes.FindAsync(id);
            
            if (toDo == null)
            {
                return NotFound();
            }

            toDo.IsDone = value;
            _context.Update(toDo);
            _context.SaveChanges();
            return PartialView("_ToDoTable", GetMyToDoes());
        }
          
        

        // POST: ToDoes/Delete/5
       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDo = await _context.ToDoes.FindAsync(id);
            _context.ToDoes.Remove(toDo);
            await _context.SaveChangesAsync();
            return PartialView("_ToDoTable", GetMyToDoes());
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDoes.Any(e => e.Id == id);
        }
    }
}
