using System.Collections.Generic;
using System.Linq;

namespace SixLetterWordExercise
{
    public class SixLettersAlgorithm
    {
        private readonly HashSet<string>[] _storageByStringLength;
        private readonly IList<(string, string)> _result = new List<(string, string)>();
        private const int Target = 6;

        public SixLettersAlgorithm(IEnumerable<string> input)
        {
            _storageByStringLength = new HashSet<string>[Target + 1];
            for (var i = 0; i < _storageByStringLength.Length; ++i)
            {
                _storageByStringLength[i] = new HashSet<string>();
            }

            // According to this logic, each string with length L will be put into the cell [L]
            // e.g. _storageByStringLength[1] contains {"a","b"}, _storageByStringLength[2] contains {"ab", "bc"}, etc
            foreach (var line in input)
            {
                _storageByStringLength[line.Length].Add(line);
            }
        }

        public IEnumerable<(string, string)> FindAllMatches()
        {
            var sixLettersList = _storageByStringLength[Target];

            for (var i = 1; i < Target; ++i)
            {
                var iLettersList = _storageByStringLength[i];
                var matchesLettersList = _storageByStringLength[Target - i];

                foreach (var prefix in iLettersList)
                {
                    if (!sixLettersList.Any(x => x.StartsWith(prefix))) continue;

                    var allPossible = sixLettersList.Where(x => x.StartsWith(prefix));
                    foreach (var match in allPossible)
                    {
                        var second = matchesLettersList.FirstOrDefault(x => x == match[i..]);
                        if (second != null)
                        {
                            _result.Add((prefix, second));
                        }
                    }
                }
            }

            return _result;
        }
    }
}