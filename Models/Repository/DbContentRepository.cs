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

        public void Create(Film film, List<int> selectedGenre, List<int> selectedCast)
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

        public void Delete(Content content)
        {
            throw new NotImplementedException();
        }

        public Film GetFilmById(int id)
        {
            return db.Films.Where(f => f.Id == id).Include("Casts").Include("Genres").FirstOrDefault();
        }

        public SerieTV GetSerieById(int id)
        {
            return db.SerieTVs.Where(s => s.Id == id).Include("Casts").Include("Genres").Include("Seasons").FirstOrDefault();
        }

        public List<Content> SearchByTitle(string? title)
        {
            throw new NotImplementedException();
        }

        public void Update(Content content, Content formData, List<int>? selectedGenre)
        {
            throw new NotImplementedException();
        }
    }
}
