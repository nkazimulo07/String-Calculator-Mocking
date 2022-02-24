using StringCalculatorTask.Interfaces;

namespace StringCalculatorTask.Services
{
    public class ErrorHandlingService : IErrorHandling
    {
        public string ThrowException(string exception)
        {
            throw new Exception(exception);
        }
    }
}
