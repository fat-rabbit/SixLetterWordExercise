using System.Collections.Generic;
using System.IO;

namespace SixLetterWordExercise
{
    public interface IDataProvider
    {
        IEnumerable<string> ReadLines();
    }

    public class DataFileProvider : IDataProvider
    {
        private readonly string _source;

        public DataFileProvider(string fileSource)
        {
            if (!File.Exists(fileSource))
                throw new FileNotFoundException();
            _source = fileSource;
        }

        public IEnumerable<string> ReadLines()
        {
            var fileLines = new List<string>();
            using (var file = new StreamReader(_source))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    fileLines.Add(line);
                }
            }

            return fileLines;
        }
    }
}