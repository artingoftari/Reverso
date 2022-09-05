using MediatR;
using Reverso.Application.Phrase.ViewModels;
using Reverso.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Application.Phrase
{
    public class ReversePhraseCommandHandler : IRequestHandler<ReversePhraseCommand, PhraseViewModel>
    {
        private ReversoDbContext _phraseReverserContext;
        public ReversePhraseCommandHandler(ReversoDbContext phraseReverserContext)
        {
            _phraseReverserContext = phraseReverserContext;
        }


        public async Task<PhraseViewModel> Handle(ReversePhraseCommand command, CancellationToken cancellationToken)
        {
            Domain.Phrase phraseToReverse = new(command.PhraseToReverse);

            await _phraseReverserContext.ReversedPhrases.AddAsync(phraseToReverse, cancellationToken);
            await _phraseReverserContext.SaveChangesAsync(cancellationToken);

            return new PhraseViewModel(phraseToReverse);
        }
    }
}
