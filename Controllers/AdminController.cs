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

        public IActionResult CreateFilm()
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
        public IActionResult CreateFilm(FormData formData)
        {
            formData.Film.Remaining_time = formData.Film.Duration;
            if (!ModelState.IsValid)
            {             
                formData.Genres = new List<SelectListItem>();
                List<Genre> genresList = db.Genres.ToList();
                foreach (Genre genre in genresList)
                {
                    formData.Genres.Add(new SelectListItem(genre.Name, genre.Id.ToString()));
                }

                formData.Casts = new List<SelectListItem>();
                List<Cast> castList = db.Casts.ToList();
                foreach (Cast cast in castList)
                {
                    formData.Casts.Add(new SelectListItem(cast.Nome + " " + cast.Lastnome, cast.Id.ToString()));
                }

                return View(formData);
            }
            
            boolflixRepository.CreateFilm(formData.Film, formData.SelectedGenres, formData.SelectedCasts);
            
            return RedirectToAction("Index","Home");
        }

        public IActionResult CreateSerie()
        {
            FormData formData = new FormData();

            formData.Serie = new SerieTV();
            formData.Genres = new List<SelectListItem>();
            formData.Casts = new List<SelectListItem>();

            List<Cast> castList = db.Casts.ToList();

            foreach (Cast cast in castList)
            {
                formData.Casts.Add(new SelectListItem(cast.Nome + " " + cast.Lastnome, cast.Id.ToString()));
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
        public IActionResult CreateSerie(FormData formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Genres = new List<SelectListItem>();
                List<Genre> genresList = db.Genres.ToList();
                foreach (Genre genre in genresList)
                {
                    formData.Genres.Add(new SelectListItem(genre.Name, genre.Id.ToString()));
                }

                formData.Casts = new List<SelectListItem>();
                List<Cast> castList = db.Casts.ToList();
                foreach (Cast cast in castList)
                {
                    formData.Casts.Add(new SelectListItem(cast.Nome + " " + cast.Lastnome, cast.Id.ToString()));
                }

                return View(formData);
            }

            boolflixRepository.CreateSerie(formData.Serie, formData.SelectedGenres, formData.SelectedCasts);

            return RedirectToAction("Index","Home");
        }

        public IActionResult UpdateFilm(int id)
        {

            Film film = boolflixRepository.GetFilmById(id);

            if (film == null)
                return NotFound();

            FormData formData = new FormData();

            formData.Film = film;
            formData.Genres = new List<SelectListItem>();
            formData.Casts = new List<SelectListItem>();

            List<Cast> castList = db.Casts.ToList();

            foreach (Cast cast in castList)
            {
                formData.Casts.Add(new SelectListItem(cast.Nome + " " + cast.Lastnome, cast.Id.ToString(), film.Casts.Any(t => t.Id == cast.Id)));
            }

            List<Genre> genresList = db.Genres.ToList();

            foreach (Genre genre in genresList)
            {
                formData.Genres.Add(new SelectListItem(genre.Name, genre.Id.ToString(),film.Genres.Any(t => t.Id == genre.Id)));
            }

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFilm(int id, FormData formData)
        {

            if (!ModelState.IsValid)
            {
                formData.Film.Id = id;
                //return View(postItem);
                formData.Genres = new List<SelectListItem>();
                List<Genre> genresList = db.Genres.ToList();
                foreach (Genre genre in genresList)
                {
                    formData.Genres.Add(new SelectListItem(genre.Name, genre.Id.ToString()));
                }

                formData.Casts = new List<SelectListItem>();
                List<Cast> castList = db.Casts.ToList();
                foreach (Cast cast in castList)
                {
                    formData.Casts.Add(new SelectListItem(cast.Nome + " " + cast.Lastnome, cast.Id.ToString()));
                }

                return View(formData);
            }

            //update esplicito con nuovo oggetto
            Film filmItem = boolflixRepository.GetFilmById(id);

            if (filmItem == null)
            {
                return NotFound();
            }

            boolflixRepository.UpdateFilm(filmItem, formData.Film,formData.SelectedGenres,formData.SelectedCasts);

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFilm(int id)
        {
            Film filmTodelete = boolflixRepository.GetFilmById(id);

            if (filmTodelete == null)
            {
                return NotFound();
            }

            boolflixRepository.DeleteFilm(filmTodelete);


            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSerie(int id)
        {
            SerieTV serieTodelete = boolflixRepository.GetSerieById(id);

            if (serieTodelete == null)
            {
                return NotFound();
            }

            foreach(Season seasons in serieTodelete.Seasons)
            {
                if(seasons.Episodes != null)
                {
                    seasons.Episodes.Clear();
                }

                db.SaveChanges();
            }

            boolflixRepository.DeleteSerie(serieTodelete);


            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateSeason(int id)
        {
            SerieTV serieTV = boolflixRepository.GetSerieById(id);
            
            Season season = new Season();
            season.SeasonNumber = serieTV.Seasons.Count() + 1;
            season.SerieTV = serieTV;
            season.SerieTVId = id;
            
            db.Seasons.Add(season);
            db.SaveChanges();

            return RedirectToAction("DetailSerie", "Home", new { ID = id });
        }
    }
}
