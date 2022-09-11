using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Base
{
    public static class StringExtensions
    {
        public static string ReversePhrase(this string phraseToReverse, params char[] immovableCharacters)
        {
            string[] wordsToReverse = phraseToReverse.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> reversedWords = new();

            foreach (string wordToReverse in wordsToReverse)
            {
                string reversedWord = ReverseWord(wordToReverse, immovableCharacters);
                reversedWords.Add(reversedWord);
            }
            return string.Join(" ", reversedWords);
        }
        private static string ReverseWord(string wordToReverse, char[] immovableCharacters)
        {
            if (wordToReverse.Any(w => immovableCharacters.Contains(w)))
            {
                string[] wordsWithImmovableCharacters = wordToReverse.Split(immovableCharacters, StringSplitOptions.RemoveEmptyEntries);
                foreach (string specialWordToReverse in wordsWithImmovableCharacters)
                {
                    char[] specialReversedWord = specialWordToReverse.Reverse().ToArray();
                    wordToReverse = wordToReverse.Replace(specialWordToReverse, new string(specialReversedWord));
                }
                return wordToReverse;
            }
            else
            {
                char[] reversedWord = wordToReverse.Reverse().ToArray();
                wordToReverse = wordToReverse.Replace(wordToReverse, new string(reversedWord));
                return wordToReverse;
            }
        }
    }
}
