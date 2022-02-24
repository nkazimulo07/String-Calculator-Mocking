using StringCalculatorTask.Interfaces;

namespace StringCalculatorTask.Services
{
    public class NumbersService : INumbers
    {
        private readonly INegativeNumbers _negativeNumbers;
        public NumbersService(INegativeNumbers negativeNumbers)
        {
            _negativeNumbers = negativeNumbers;
        }

        public List<int> ConvertStringArrayToIntList(string[] numbers)
        {
            List<int> numbersList = new List<int>();

            foreach (string number in numbers)
            {
                numbersList.Add(Convert.ToInt32(number));
            }

             _negativeNumbers.CheckNegativeNumbers(numbersList);

            return GetNumbersLessThanOneThousand(numbersList);
        }

        public List<int> GetNumbersLessThanOneThousand(List<int> numbers)
        {
            var numbersList = new List<int>();

            foreach (var number in numbers)
            {
                if (number < 1000)
                {
                    numbersList.Add(number);
                }
            }

            return numbersList;
        }

    }
}
