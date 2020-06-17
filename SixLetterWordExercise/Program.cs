namespace SixLetterWordExercise
{
    class Program
    {
        private static readonly IPrinter Printer = new Printer();
        private static readonly IDataProvider DataProvider = new DataFileProvider("input.txt");
        
        static void Main(string[] args)
        {
            var input = DataProvider.ReadLines();
            var algorithm = new SixLettersAlgorithm(input);
            Printer.Print(algorithm.FindAllMatches());
        }
    }
}