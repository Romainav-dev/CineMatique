using CineMatique.Views;
using Domain.Entities.Films;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CineMatique.Controllers
{
    [Route("Films")] // Définit la route de base
    public class FilmController : Controller
    {
        private ApplicationDbContext _context;

        public FilmController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Films/Create
        // GET: Films/Create
        [HttpGet]
        public IActionResult Create()
        {
            var genres = _context.Genres.ToList(); // Récupère tous les genres de la base de données
            var model = new FilmCreateViewModel
            {
                Film = new Film(), // Crée un nouvel objet Film
                Genres = genres // Remplit la liste des genres
            };
            return View(model); // Passe le modèle à la vue
        }

        [HttpPost]
        public IActionResult Create(FilmCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Vous pouvez aussi le logger ou l'afficher dans la vue
                }
        
                // Réinjecter la liste des genres si le modèle n'est pas valide
                model.Genres = _context.Genres.ToList();
                return View(model);
            }

            // Si tout est valide, ajoutez le film à la base de données
            var film = model.Film;
            _context.Films.Add(film);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}