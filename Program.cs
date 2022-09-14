using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    class Programm
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText(@"C:\Users\vladp\source\repos\TextAnalysis\Harry_Potter.txt");

            List<List<string>> words = SentencesParser.ParseSentences(text);
            Dictionary<string, string> pairs = FrequencyAnalysis.GetMostFrequentNextWords(words);
            string result = TextGenerator.ContinuePhrase(pairs, "a", 5);
            Console.WriteLine(result);
        }
    }
}