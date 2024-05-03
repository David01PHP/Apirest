using Microsoft.AspNetCore.Mvc;
using Apirest.Data;
using Apirest.Models;


namespace Apirest.Controllers
{
    [ApiController]
    [Route("Api/[controller]")] 
    public class SearchController : Controller
    {
        private readonly DataContext _context;

        public SearchController(DataContext context)
        {
            _context = context;
        }


          //buscar por title

        
        [HttpGet("{titulo}")]
          public ActionResult<IEnumerable<Note>> Get(string titulo)
        {
            
            var resultados = _context.Notes.Where(e => e.Title.Contains(titulo)).ToList();

            if (resultados.Count == 0)
            {
                return NotFound(); 
            }

            return StatusCode(200, resultados); 
        }
    }
}