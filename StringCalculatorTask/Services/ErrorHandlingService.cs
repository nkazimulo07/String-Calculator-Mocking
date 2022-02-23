using StringCalculatorTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
