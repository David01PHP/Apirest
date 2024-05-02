using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Apirest.Models;
using Apirest.Data;
using Microsoft.EntityFrameworkCore;

namespace Apirest.Controllers
{
    [ApiController]
    [Route("Api/[controller]")] //api/Notes
    public class NotesController : ControllerBase
    {
        private readonly DataContext _context;

        public NotesController(DataContext context)
        {
            _context = context;
        }


        // GET: api/Note
        [HttpGet]
        public  ActionResult<IEnumerable<Note>> GetNotes()
        {
            return  _context.Notes.ToList();
        }

        // GET: api/Note/{id}
        [HttpGet("{id}")]
        public async  Task<ActionResult<Note>> GetNotes(int id)
        {
            var note = await _context.Notes.FindAsync(id);

            if(note == null)
            {
                return NotFound();
            }
            return note;
        }


        // POST: api/Person
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostNote", new { id = note.Id }, note);//tira un codigo 201 si se creo con exito
        }

        /*
         [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("PostTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(PostNote), new { id = note.Id }, note);
        }*/

        

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if(note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return NoContent();// no se necesita retorna nada y rtorna 204 si est amelo
        }


        // PUT: api/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();//tira un codogo 204
        }

         private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}