namespace Boolflix.Models.Repository
{
    public class DbContentRepository : IdbContentRepository
    {
        public List<Content> All()
        {
            throw new NotImplementedException();
        }

        public List<Content> AllFilm()
        {
            throw new NotImplementedException();
        }

        public List<Content> AllSeries()
        {
            throw new NotImplementedException();
        }

        public void Create(Content content, List<int> selectedGenre)
        {
            throw new NotImplementedException();
        }

        public void Delete(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
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
