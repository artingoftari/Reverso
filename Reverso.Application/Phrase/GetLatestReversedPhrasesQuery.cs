using MediatR;
using Reverso.Application.Phrase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Application.Phrase
{
    public class GetLatestReversedPhrasesQuery : IRequest<List<PhraseViewModel>>
    {
        public int? Page { get; set; } = 1;
        public int? Size { get; set; } = 5;
    }
}
