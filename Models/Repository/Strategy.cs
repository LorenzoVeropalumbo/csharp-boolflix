using Boolflix.Data;
using Boolflix.Models.DataHome;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Boolflix.Models.Repository
{
    public interface Strategy
    {
        public abstract IndexData AlgorithmInterface(string Genre, BoolflixDbContext db);
    }

    public class SearchByCategory : Strategy
    {
        public IndexData AlgorithmInterface(string genre, BoolflixDbContext db)
        {
            List<SerieTV> serieTVs = db.SerieTVs.Include("Genres").ToList();
            List<SerieTV> serieTVsFiltered = new List<SerieTV>();
            foreach (SerieTV serieTV in serieTVs)
            {
                foreach (Genre genre1 in serieTV.Genres)
                {
                    if (genre1.Name == genre)
                    {
                        serieTVsFiltered.Add(serieTV);
                    }
                }
            }
            List<Film> films = db.Films.Include("Genres").ToList();
            List<Film> filmsFiltered = new List<Film>();
            foreach (Film film in films)
            {
                foreach (Genre genre1 in film.Genres)
                {
                    if (genre1.Name == genre)
                    {
                        filmsFiltered.Add(film);
                    }
                }
            }
            IndexData indexData = new IndexData();
            indexData.Films = filmsFiltered;
            indexData.Series = serieTVsFiltered;
            return indexData;
        }
    }
}
