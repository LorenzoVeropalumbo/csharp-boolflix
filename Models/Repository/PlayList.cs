namespace Boolflix.Models.Repository
{
    public class PlayList
    {
        Strategy strategy;
        // Constructor
        public PlayList(Strategy strategy)
        {
            this.strategy = strategy;
        }
        
        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }


}