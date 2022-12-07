using Boolflix.Data;
using Boolflix.Models;
using Boolflix.Models.DataHome;
using Boolflix.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Boolflix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public BoolflixDbContext db;
        IdbContentRepository boolflixRepository;

        public HomeController(ILogger<HomeController> logger, IdbContentRepository _boolflixRepository, BoolflixDbContext _db) : base()
        {
            _logger = logger;

            db = _db;
            boolflixRepository = _boolflixRepository;
        }

        public IActionResult Index()
        {
            IndexData2 indexData2 = new IndexData2();
            indexData2.IndexDataAzione = boolflixRepository.SearchByGenre("Azione");
            indexData2.IndexDataAvventura = boolflixRepository.SearchByGenre("Avventura");
            indexData2.IndexDataHorror = boolflixRepository.SearchByGenre("Horror");
            indexData2.IndexDataFantasy = boolflixRepository.SearchByGenre("Fantasy");
            
            return View(indexData2);
        }

        public IActionResult DetailFilm(int id)
        {
            Film film = boolflixRepository.GetFilmById(id);
            return View(film);
        }
        public IActionResult DetailSerie(int id)
        {
            SerieTV serieTV = boolflixRepository.GetSerieById(id);

            return View(serieTV);
        }

        public IActionResult IndexFilm(int id)
        {
            List<Film> films = boolflixRepository.AllFilm();
            return View(films);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}