using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class TextGenerator
    {
        public static string ContinuePhrase(Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
        {
            var result = new List<string>();
            result.AddRange(phraseBeginning.ToLower().Split(' '));

            for (int i = 0; i < wordsCount; i++)
            {
                if (result.Count >= 2 && nextWords.ContainsKey(result[result.Count() - 2] + " " + result.Last()))
                    result.Add(nextWords[result[result.Count() - 2] + " " + result.Last()]);

                else if (nextWords.ContainsKey(result.Last()))
                    result.Add(nextWords[result.Last()]);

                else
                    return string.Join(" ", result.ToArray());
            }

            return string.Join(" ", result.ToArray());
        }
    }
}