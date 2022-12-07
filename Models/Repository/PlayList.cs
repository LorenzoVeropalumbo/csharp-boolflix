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
        
        public void EseguiStrategy(Strategy strategy,string Genre)
        {
            strategy.AlgorithmInterface(Genre);
        }
    }


}