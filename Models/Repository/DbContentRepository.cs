using Azure;
using Boolflix.Data;
using Boolflix.Models.DataHome;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;

namespace Boolflix.Models.Repository
{
    public class DbContentRepository : IdbContentRepository
    {
        private BoolflixDbContext db;

        public DbContentRepository(BoolflixDbContext _db)
        {
            db = _db;
        }
        public IndexData All()
        {
            IndexData indexData = new IndexData();
            indexData.Films = db.Films.Include("Casts").Include("Genres").ToList();
            indexData.Series = db.SerieTVs.Include("Casts").Include("Genres").Include("Seasons").ToList();
            return indexData;
        }

        public List<Film> AllFilm()
        {
            return db.Films.ToList();
        }

        public List<SerieTV> AllSeries()
        {
            return db.SerieTVs.ToList();
        }        
        
        public Film GetFilmById(int id)
        {
            return db.Films.Where(f => f.Id == id).Include("Casts").Include("Genres").FirstOrDefault();
        }

        public SerieTV GetSerieById(int id)
        {
            return db.SerieTVs.Where(s => s.Id == id).Include("Casts").Include("Genres").Include("Seasons").Include("Seasons.Episodes").FirstOrDefault();
        }

        public void CreateFilm(Film film, List<int> selectedGenre, List<int> selectedCast)
        {
            film.Genres = new List<Genre>();

            foreach (int genreId in selectedGenre)
            {
                //todo: implementare repository tag?
                Genre genre = db.Genres.Where(t => t.Id == genreId).FirstOrDefault();
                film.Genres.Add(genre);
            }

            film.Casts = new List<Cast>();
            foreach (int castId in selectedCast)
            {
                //todo: implementare repository tag?
                Cast cast = db.Casts.Where(t => t.Id == castId).FirstOrDefault();
                film.Casts.Add(cast);
            }

            film.AlreadySeen = false;
            film.Remaining_time = film.Duration;
            db.Films.Add(film);
            db.SaveChanges();
        }        
        
        public void CreateSerie(SerieTV serie, List<int> selectedGenre, List<int> selectedCast)
        {
            serie.Genres = new List<Genre>();

            foreach (int genreId in selectedGenre)
            {
                //todo: implementare repository tag?
                Genre genre = db.Genres.Where(t => t.Id == genreId).FirstOrDefault();
                serie.Genres.Add(genre);
            }

            serie.Casts = new List<Cast>();
            foreach (int castId in selectedCast)
            {
                //todo: implementare repository tag?
                Cast cast = db.Casts.Where(t => t.Id == castId).FirstOrDefault();
                serie.Casts.Add(cast);
            }

            serie.AlreadySeen = false;           
            db.SerieTVs.Add(serie);
            db.SaveChanges();
        }

        public void UpdateFilm(Film film, Film formData, List<int>? selectedGenre, List<int>? selectedCast)
        {
            if (selectedGenre == null)
            {
                selectedGenre = new List<int>();
            }

            film.Title = formData.Title;
            film.Description = formData.Description;
            film.Poster = formData.Poster;
            film.PG = formData.PG;
            film.Year = formData.Year;
            film.Compatibility = formData.Compatibility;

            film.Genres.Clear();


            foreach (int genresId in selectedGenre)
            {
                Genre genre = db.Genres.Where(t => t.Id == genresId).FirstOrDefault();
                film.Genres.Add(genre);
            }

            film.Casts.Clear();


            foreach (int castId in selectedCast)
            {
                Cast cast = db.Casts.Where(t => t.Id == castId).FirstOrDefault();
                film.Casts.Add(cast);
            }

            db.SaveChanges();
        }

        public void DeleteFilm(Film film)
        {
            db.Films.Remove(film);
            db.SaveChanges();
        }

        public void DeleteSerie(SerieTV serieTV)
        {
            db.SerieTVs.Remove(serieTV);
            db.SaveChanges();
        }


        public List<Content> SearchByTitle(string? title)
        {
            throw new NotImplementedException();
        }

        public IndexData SearchByGenre(string genre)
        {
            PlayList playList = new PlayList();
            IStrategy strategy = new SearchByCategory();
            playList.SetStrategy(strategy);
            IndexData serieTVs = playList.EseguiStrategy(genre, db);

            return serieTVs;
        }

    }
}
