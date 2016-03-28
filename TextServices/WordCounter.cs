using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TextServices
{
    public class WordCounter
    {
        private string _allLines;
        private readonly Dictionary<string, int> _wordDictionary = new Dictionary<string, int>();
        private readonly StringBuilder _lineBuffer;

        public Dictionary<string, int> WordDictionary => _wordDictionary;

        public WordCounter()
        {
            _lineBuffer = new StringBuilder();
        }

        /// <summary>
        /// Counts words in file
        /// </summary>
        /// <param name="lines"></param>
        public void CountWordsLines(string lines)
        {
            _allLines = lines;
            ExecuteWordCount();
        }

        private void ExecuteWordCount()
        {
                TokenizeAndCount(_allLines);
        }

        private void TokenizeAndCount(string line)
        {
            foreach (var ch in line)
                if (char.IsLetter(ch))
                    _lineBuffer.Append(ch);
                else if (char.IsWhiteSpace(ch))
                    AddCountWord(_lineBuffer, _wordDictionary);

            AddCountWord(_lineBuffer, _wordDictionary);
        }

        private static void AddCountWord(StringBuilder sb, IDictionary<string, int> dict)
        {
            var word = sb.ToString();
            sb.Clear();

            if (string.IsNullOrWhiteSpace(word))
                return;

            if (dict.ContainsKey(word))
                dict[word]++;
            else
                dict.Add(word, 1);
        }
    }
}