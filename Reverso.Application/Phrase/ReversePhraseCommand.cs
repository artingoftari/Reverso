using MediatR;
using Reverso.Application.Phrase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Application.Phrase
{
    public class ReversePhraseCommand : IRequest<PhraseViewModel>
    {
        public string PhraseToReverse { get; set; }
    }
}
