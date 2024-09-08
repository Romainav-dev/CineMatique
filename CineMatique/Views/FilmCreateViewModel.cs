using Domain.Entities.Films;
using System.Collections.Generic;

namespace CineMatique.Views
{
    public class FilmCreateViewModel
    {
        public Domain.Entities.Films.Film Film { get; set; } // Propriété pour l'objet Film
        public List<Genre> Genres { get; set; } // Liste des genres disponibles
    }
}