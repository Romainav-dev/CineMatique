using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence; // Assurez-vous d'importer le bon namespace

namespace CineMatique.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /genre
        [HttpGet]
        public IActionResult GetAllGenres()
        {
            Console.WriteLine("Accès à la méthode GetGenres");
            var genres = _context.Genres.ToList();
            Console.WriteLine($"Genres récupérés : {string.Join(", ", genres.Select(g => g.Name))}");
            return Ok(genres);
        }
    }
}