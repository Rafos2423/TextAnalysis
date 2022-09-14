using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    class SentencesParser
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            char[] separators = { '.', '!', '?', ';', ':', '(', ')' };
            string[] sentences = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sentence in sentences)
            {
                if (sentence.Length > 0)
                    sentencesList.Add(SplitSentanceToWords(sentence));
            }

            sentencesList.RemoveAll(x => x == null || x.Count == 0);
            return sentencesList;
        }

        private static List<string> SplitSentanceToWords(string sentence)
        {
            var words = new List<string>();
            var word = new StringBuilder();

            foreach (var symbol in sentence)
            {
                if (char.IsLetter(symbol) || (symbol == '\''))
                    word.Append(symbol);

                else if (word.Length > 0)
                {
                    words.Add(word.ToString().ToLower());
                    word.Remove(0, word.Length);
                }
            }

            if (word.Length > 0)
                words.Add(word.ToString().ToLower());

            return words;
        }
    }
}
