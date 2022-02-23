using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTask.Interfaces
{
    public interface INumbers
    {
        List<int> ConvertStringArrayToIntList(string[] numbers);
    }
}
