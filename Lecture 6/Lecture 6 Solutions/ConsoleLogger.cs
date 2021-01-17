using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_6_Potential_Solutions
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
