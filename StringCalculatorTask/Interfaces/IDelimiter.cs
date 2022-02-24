namespace StringCalculatorTask.Interfaces
{
    public interface IDelimiter
    {
        List<string> GetDelimiters(string numbers);
        List<string> GetMultipleDelimiters(string delimiter);
    }
}
