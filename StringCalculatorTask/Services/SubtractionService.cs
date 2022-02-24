namespace StringCalculatorTask.Services
{
    public class SubtractionService : ICalculation
    {
        public int Calculate(List<int> numbers)
        {
            var difference = numbers.First();

            for (int i = 1; i < numbers.Count; i++)
            {
                difference -= numbers[i];
            }

            return difference;
        }
    }
}
