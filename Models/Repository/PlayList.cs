using Boolflix.Data;
using Boolflix.Models.DataHome;

namespace Boolflix.Models.Repository
{
    public class PlayList
    {
        public IStrategy strategy;
        // Constructor
        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }
        
        public IndexData EseguiStrategy(string Genre, BoolflixDbContext db)
        {
            return strategy.AlgorithmInterface(Genre, db);
        }
    }


}