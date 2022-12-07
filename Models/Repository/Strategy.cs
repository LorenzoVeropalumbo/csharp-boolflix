namespace Boolflix.Models.Repository
{
    public interface Strategy
    {
        public abstract void AlgorithmInterface(string Genre);
    }

    public class SearchByCategory : Strategy
    {
        public void AlgorithmInterface(string Genre)
        {
            
        }
    }
}
