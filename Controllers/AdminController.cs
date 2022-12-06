using Boolflix.Models.DataHome;
using Boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Boolflix.Data;
using Boolflix.Models.Repository;
using Azure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Hosting;

namespace Boolflix.Controllers
{   
    [Authorize]
    [Route("[controller]/[action]/{id?}", Order = 0)]
    public class AdminController : Controller
    {

        public BoolflixDbContext db;
        IdbContentRepository boolflixRepository;

        public AdminController(IdbContentRepository _boolflixRepository, BoolflixDbContext _db) : base()
        {
            db = _db;
            boolflixRepository = _boolflixRepository;
        }

        public IActionResult Create()
        {
            FormData formData = new FormData();

            formData.Film = new Film();
            formData.Genres = new List<SelectListItem>();
            formData.Casts = new List<SelectListItem>();

            List<Cast> castList = db.Casts.ToList();

            foreach (Cast cast in castList)
            {
                formData.Casts.Add(new SelectListItem(cast.Nome + " " + cast.Lastnome,cast.Id.ToString()));
            }

            List<Genre> genresList = db.Genres.ToList();

            foreach (Genre genre in genresList)
            {
                formData.Genres.Add(new SelectListItem(genre.Name, genre.Id.ToString()));
            }

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormData formData)
        {
            boolflixRepository.Create(formData.Film, formData.SelectedGenres, formData.SelectedCasts);
            
            return RedirectToAction("Index");
        }


    }
}
