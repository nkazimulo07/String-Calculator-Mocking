using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTask.Services
{
    public class AdditionService : ICalculation
    {
        public int Calculate(List<int> numbers)
        {
           return numbers.Sum();
        }
    }
}
