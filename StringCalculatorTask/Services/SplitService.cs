using StringCalculatorTask.Interfaces;

namespace StringCalculatorTask.Services
{
    public class SplitService : ISplit
    {
        string slash = "\\";
        public string[] SplitNumbers(List<string> delimiters, string numbers)
        {
            if (numbers.StartsWith(slash))
            {
                numbers = numbers.Substring(numbers.LastIndexOf('\n') + 1);
            }

            string[] numbersArray = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);

            return numbersArray;
        }
    }
}
