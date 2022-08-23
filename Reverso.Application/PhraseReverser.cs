namespace Reverso.Application
{
    public class PhraseReverser
    {
        private char[] _separators = new char[] { ' ' };
        private char[] _specialCharacters = new char[] { };
        public PhraseReverser(char[] specialCharacters)
        {
            _specialCharacters = specialCharacters;
        }
        public PhraseReverser() { }
        public string ReversePhrase(string phraseToReverse)
        {
            string[] wordsToReverse = phraseToReverse.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string wordToReverse in wordsToReverse)
            {
                //char[] reversedWord = wordToReverse.Reverse().ToArray();
                string reversedWord = ReverseWord(wordToReverse);
                phraseToReverse = phraseToReverse.Replace(wordToReverse, reversedWord);
            }

            return phraseToReverse.Trim();
        }
        private string ReverseWord(string wordToReverse)
        {
            if (wordToReverse.Any(w => _specialCharacters.Contains(w)))
            {
                string[] specialWordsToReverse = wordToReverse.Split(_specialCharacters, StringSplitOptions.RemoveEmptyEntries);
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