using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Apirest.Models;
using Apirest.Data;

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

        [HttpGet]
        public  ActionResult<IEnumerable<Note>> GetNotes()
        {
            return  _context.Notes.ToList();
        }

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
        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetNote", new {id  = note.Id}, note);
        }

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
            return NoContent();// no se necesita retorna nada
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNote(int id)
        {
             var note = await _context.Notes.FindAsync(id);
            if(note == null)
            {
                return NotFound();
            }

            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}