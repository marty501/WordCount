using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextServices;

namespace WordCount
{
    class WordCountApp
    {
        private const string FILENAME_OUTPUT = "output.txt";

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                UsageInfo();
                return;
            }

            var fileNameInput = args[0];
            var fileNameOutput = args.Length > 1 ? args[1] : Path.Combine(new FileInfo(fileNameInput).DirectoryName, FILENAME_OUTPUT);
            
            // Count words
            var wordCounter = new WordCounter();
            var allText = File.ReadAllText(fileNameInput);
            wordCounter.CountWordsLines(allText);

            // Write results
            using (var fs = new FileStream(fileNameOutput, FileMode.Create))
            using (var writer = new StreamWriter(fs))
                foreach (var keyValuePair in wordCounter.WordDictionary)
                    writer.WriteLine($"{keyValuePair.Value}: {keyValuePair.Key}");

            Console.Write("Results written to file: {0}", fileNameOutput);
        }

        /// <summary>
        /// Write usage info to the console
        /// </summary>
        private static void UsageInfo()
        {
            Console.WriteLine("\nWord Counter 2016.");
            Console.WriteLine("Usage: wordcount.exe inputFileName [outputFileName]");
            Console.WriteLine("\tinputFileName - Full input file name");
            Console.WriteLine("\toutputFileName - Full output file name. If not provided output.txt is used.");
        }
    }
}