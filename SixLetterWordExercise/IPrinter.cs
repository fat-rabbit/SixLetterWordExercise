using System;
using System.Collections.Generic;

namespace SixLetterWordExercise
{
    public interface IPrinter
    {
        void Print(IEnumerable<(string, string)> list);
    }
    
    public class Printer: IPrinter
    {
        public void Print(IEnumerable<(string, string)> list)
        {
            foreach (var (first, second) in list)
            {
                Console.WriteLine($"{first} + {second} = {first}{second}");
            }
        }
    }
}