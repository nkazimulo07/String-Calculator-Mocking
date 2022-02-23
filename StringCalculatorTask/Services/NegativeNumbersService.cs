using StringCalculatorTask.Interfaces;

namespace StringCalculatorTask.Services
{
    public class NegativeNumbersService
    {
        private readonly IErrorHandling _errorHandling;
        public NegativeNumbersService(IErrorHandling errorHandling)
        {
            _errorHandling = errorHandling;
        }

        public List<int> CheckNegativeNumbers(List<int> numbers)
        {
            var negativeNumbers = "";

            foreach (int number in numbers)
            {
                if(number < 0)
                {
                    negativeNumbers += number + " ";
                }
            }

            if (!string.IsNullOrEmpty(negativeNumbers))
            {
                _errorHandling.ThrowException("negatives not allowed:  " + negativeNumbers);
            }

            return numbers;
        }
    }
}
