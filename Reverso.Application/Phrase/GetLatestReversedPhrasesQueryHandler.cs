using MediatR;
using Microsoft.EntityFrameworkCore;
using Reverso.Application.Phrase.ViewModels;
using Reverso.Domain;
using Reverso.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Application.Phrase
{
    public class GetLatestReversedPhrasesQueryHandler : IRequestHandler<GetLatestReversedPhrasesQuery, List<PhraseViewModel>>
    {
        private ReversoDbContext _phraseReverserContext;
        public GetLatestReversedPhrasesQueryHandler(ReversoDbContext phraseReverserContext)
        {
            _phraseReverserContext = phraseReverserContext;
        }
        public async Task<List<PhraseViewModel>> Handle(GetLatestReversedPhrasesQuery query, CancellationToken cancellationToken)
        {
            return await _phraseReverserContext.ReversedPhrases.OrderByDescending(rp => rp.Reversed)
                .Skip(query.Page - 1 ?? 1)
                .Take(query.Size ?? 5)
                .Select(p => new PhraseViewModel(p))
                .ToListAsync(cancellationToken);
        }
    }
}
