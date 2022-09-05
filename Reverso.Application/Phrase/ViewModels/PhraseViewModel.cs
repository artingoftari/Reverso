using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Application.Phrase.ViewModels
{
    public class PhraseViewModel
    {
        public PhraseViewModel(Domain.Phrase phrase)
        {
            OriginalText = phrase.OriginalText;
            ReversedText = phrase.ReversedText;
            Reversed = phrase.Reversed;
        }
        public string OriginalText { get; set; }

        public string ReversedText { get; set; }

        public DateTime Reversed { get; set; }
    }
}
