using Boolflix.Models.DataHome;

namespace Boolflix.Models.Repository
{
    public interface IdbContentRepository
    {
        IndexData All();
        List<Film> AllFilm();
        List<SerieTV> AllSeries();        
        Film GetFilmById(int id);
        SerieTV GetSerieById(int id);

        void Create(Film film, List<int> selectedGenre, List<int> selectedCast);
        void Delete(Content content);

        List<Content> SearchByTitle(string? title);        
        void Update(Content content, Content formData, List<int>? selectedGenre);
    }
}
