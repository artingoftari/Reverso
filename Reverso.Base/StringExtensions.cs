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
        public static string ReversePhrase(this string phraseToReverse, params char[] specialCharacters)
        {
            string[] wordsToReverse = phraseToReverse.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string wordToReverse in wordsToReverse)
            {
                string reversedWord = ReverseWord(wordToReverse, specialCharacters);
                phraseToReverse = phraseToReverse.Replace(wordToReverse, reversedWord);
            }

            return phraseToReverse.Trim();
        }
        private static string ReverseWord(string wordToReverse, char[] specialCharacters)
        {
            if (wordToReverse.Any(w => specialCharacters.Contains(w)))
            {
                string[] specialWordsToReverse = wordToReverse.Split(specialCharacters, StringSplitOptions.RemoveEmptyEntries);
                foreach (string specialWordToReverse in specialWordsToReverse)
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
