namespace Boolflix.Models.Repository
{
    public interface IdbContentRepository
    {
        List<Content> All();
        List<Content> AllFilm();
        List<Content> AllSeries();
        void Create(Content content, List<int> selectedGenre);
        void Delete(Content content);
        Content GetById(int id);
        List<Content> SearchByTitle(string? title);        
        void Update(Content content, Content formData, List<int>? selectedGenre);
    }
}
