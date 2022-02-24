using StringCalculatorTask.Interfaces;

namespace StringCalculatorTask.Services
{
    public class DelimiterService : IDelimiter
    {
        string slash = "//";
        char leftSquareBracket = '[';
        char rightSquareBracket = ']';
        string squareBrackets = "][";
        string newLine = "\n";
        public List<string> GetDelimiters(string numbers)
        {
            List<string> delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith(slash))
            {
                var delimiter = numbers.Substring(2, numbers.IndexOf(newLine) - 2);

                if (delimiter.Contains(leftSquareBracket.ToString()) && delimiter.Contains(rightSquareBracket.ToString()))
                {
                    delimiters.AddRange(GetMultipleDelimiters(delimiter));
                }
                else
                {
                    delimiters.Add(delimiter);
                }
            }

            return delimiters;
        }

        public List<string> GetMultipleDelimiters(string delimiter)
        {
            char[] charsToTrim = { leftSquareBracket, rightSquareBracket };
            string cleanDelimiter = delimiter.Trim(charsToTrim);
            string[] delimiters = cleanDelimiter.Split(new string[] { squareBrackets }, StringSplitOptions.RemoveEmptyEntries);

            return delimiters.ToList();
        }
    }
}
