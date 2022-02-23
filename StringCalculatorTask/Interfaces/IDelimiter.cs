using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTask.Interfaces
{
    public interface IDelimiter
    {
        List<string> GetDelimiters(string numbers);
        List<string> GetMultipleDelimiters(string delimiter);
    }
}
