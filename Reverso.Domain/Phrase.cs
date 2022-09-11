using Reverso.Base;
using System.ComponentModel.DataAnnotations;

namespace Reverso.Domain
{
    public class Phrase
    {
        public Phrase(string text, params char[] immovableCharacters)
        {
            OriginalText = text;
            ReversedText = text.ReversePhrase(immovableCharacters);
            Reversed = DateTime.Now;
        }
        public Phrase() { }
        public int Id { get; set; }

        public string OriginalText { get; set; }

        public string ReversedText { get; set; }

        public DateTime Reversed { get; set; }
    }
}