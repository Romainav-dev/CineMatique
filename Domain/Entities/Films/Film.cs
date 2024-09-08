using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Domain.Entities.Films;

namespace Domain.Entities.Films;

public class Film
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le Title est requis")] public string Title { get; set; }

    [Required(ErrorMessage = "Le Description est requis")] public string Description { get; set; }

    [Required(ErrorMessage = "Le DateCreated est requis")] public DateTime DateCreated { get; set; }

    [Required(ErrorMessage = "Le Duration est requis")] public string Duration { get; set; }

    [Required(ErrorMessage = "Le GenreId est requis")] public int GenreId { get; set; }
    public Genre Genre { get; set; }
}