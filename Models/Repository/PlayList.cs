using Boolflix.Data;
using Boolflix.Models.DataHome;

namespace Boolflix.Models.Repository
{
    public class PlayList
    {
        private Strategy strategy;
        // Constructor
        public void SetStrategy(Strategy strategy)
        {
            this.strategy = strategy;
        }
        
        public IndexData EseguiStrategy(Strategy strategy,string Genre, BoolflixDbContext db)
        {
            return strategy.AlgorithmInterface(Genre, db);
        }
    }


}