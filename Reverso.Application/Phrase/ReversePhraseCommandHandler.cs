using MediatR;
using Reverso.Application.Configuration;
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
        private ReversePhraseConfiguration _config;
        private ReversePhraseValidator _validator;
        public ReversePhraseCommandHandler(ReversoDbContext phraseReverserContext, ReversePhraseConfiguration config)
        {
            _phraseReverserContext = phraseReverserContext;
            _config = config;
            _validator = new ReversePhraseValidator(_config);
        }


        public async Task<PhraseViewModel> Handle(ReversePhraseCommand command, CancellationToken cancellationToken)
        {
            PhraseValidation validationResult = _validator.Validate(command);
            if (!validationResult.Valid)
            {
                throw new ArgumentException(validationResult.Message);
            }
            Domain.Phrase phraseToReverse = new(command.PhraseToReverse, _config.ImmovableCharacters.ToCharArray());

            await _phraseReverserContext.ReversedPhrases.AddAsync(phraseToReverse, cancellationToken);
            await _phraseReverserContext.SaveChangesAsync(cancellationToken);

            return new PhraseViewModel(phraseToReverse);
        }
    }
}
