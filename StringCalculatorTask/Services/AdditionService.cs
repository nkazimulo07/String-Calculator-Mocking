namespace StringCalculatorTask.Services
{
    public class AdditionService : ICalculation
    {
        public int Calculate(List<int> numbers)
        {
            return numbers.Sum();
        }
    }
}
