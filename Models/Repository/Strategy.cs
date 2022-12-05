namespace Boolflix.Models.Repository
{
    public interface Strategy
    {
        public abstract void AlgorithmInterface();
    }

    public class getSeries : Strategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }
}
