using Boolflix.Models.DataHome;
using Microsoft.AspNetCore.Mvc;

namespace Boolflix.Models.Repository
{
    public interface IdbContentRepository
    {
        IndexData All();
        List<Film> AllFilm();
        List<SerieTV> AllSeries();        
        Film GetFilmById(int id);
        SerieTV GetSerieById(int id);

        void CreateFilm(Film film, List<int> selectedGenre, List<int> selectedCast);
        void CreateSerie(SerieTV serie, List<int> selectedGenre, List<int> selectedCast);
        void UpdateFilm(Film film, Film formData, List<int>? selectedGenre, List<int>? selectedCast);
        void DeleteFilm(Film film);
        void DeleteSerie(SerieTV serieTV);

        List<Content> SearchByTitle(string? title);        
        
    }
}
