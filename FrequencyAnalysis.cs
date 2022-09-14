using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysis
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var allPairs = FindPairs(text);
            var oftenPairs = TakeOftenPairs(allPairs);
            var result = new Dictionary<string, string>();

            foreach (var pair in oftenPairs)
                result.Add(pair.Key, pair.Value.Item1);

            return result;
        }

        private static Dictionary<string, (string, int)> TakeOftenPairs(Dictionary<(string, string), int> allPairs)
        {
            var oftenPairs = new Dictionary<string, (string lastContinuation, int lastValue)>();

            foreach (var pair in allPairs)
            {
                var beginning = pair.Key.Item1;
                var continuation = pair.Key.Item2;

                if (!oftenPairs.ContainsKey(beginning))
                    oftenPairs.Add(beginning, (continuation, pair.Value));

                else if (oftenPairs[beginning].lastValue < pair.Value)
                    oftenPairs[beginning] = (continuation, pair.Value);

                else if (oftenPairs[beginning].lastValue == pair.Value &&
                    string.CompareOrdinal(oftenPairs[beginning].lastContinuation, continuation) > 0)
                    oftenPairs[beginning] = (continuation, pair.Value);
            }

            return oftenPairs;
        }

        private static Dictionary<(string, string), int> FindPairs(List<List<string>> text)
        {
            var pairs = new Dictionary<(string, string), int>();

            foreach (var sentence in text)
            {
                for (int word = 1; word < sentence.Count; word++)
                    AddToDictionary(pairs, sentence[word - 1], sentence[word]);

                for (int word = 2; word < sentence.Count; word++)
                    AddToDictionary(pairs, sentence[word - 2] + ' ' + sentence[word - 1], sentence[word]);
            }

            return pairs;
        }

        private static void AddToDictionary(Dictionary<(string, string), int> pairs, string beginning, string continuation)
        {
            if (!pairs.ContainsKey((beginning, continuation)))
                pairs.Add((beginning, continuation), 1);
            else
                pairs[(beginning, continuation)]++;
        }
    }
}