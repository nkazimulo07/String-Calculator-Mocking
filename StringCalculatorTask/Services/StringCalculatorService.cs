using StringCalculatorTask.Interfaces;

namespace StringCalculatorTask
{
    public class StringCalculatorService
    {
        private readonly ICalculation _calculator;
        private readonly IDelimiter _delimiter;
        private readonly ISplit _split;
        private readonly INumbers _numbers;
        public StringCalculatorService(ICalculation calculator, IDelimiter delimiter, ISplit split, INumbers numbers)
        {
            _calculator = calculator;
            _delimiter = delimiter;
            _split = split;
            _numbers = numbers;
        }
        public int PerformCalculation(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            var numbersList = getNumbersList(numbers);

            return _calculator.Calculate(numbersList);
        }

        public List<int> getNumbersList(string numbers)
        {
            var delimiters = _delimiter.GetDelimiters(numbers);
            var splitedNumbers = _split.SplitNumbers(delimiters,numbers);
            var numbersList = _numbers.ConvertStringArrayToIntList(splitedNumbers);

            return numbersList;

        }
    }
}