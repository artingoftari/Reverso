using Microsoft.EntityFrameworkCore;
using Reverso.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Application.Tests.Infrastructure
{
    internal class TestContextFactory
    {
        internal static ReversoDbContext CreateMockContext()
        {
            var options = new DbContextOptionsBuilder<ReversoDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new ReversoDbContext(options);

            context.ReversedPhrases.Add(new Domain.Phrase { Id = 1, OriginalText = "TestPhrase number One", ReversedText = "enO rebmun esarhPtseT", Reversed = new DateTime(2022, 8, 1) });
            context.ReversedPhrases.Add(new Domain.Phrase { Id = 2, OriginalText = "TestPhrase number Two", ReversedText = "owT rebmun esarhPtseT", Reversed = new DateTime(2022, 8, 2) });
            context.ReversedPhrases.Add(new Domain.Phrase { Id = 3, OriginalText = "TestPhrase number Three", ReversedText = "eerhT rebmun esarhPtseT", Reversed = new DateTime(2022, 8, 3) });
            context.ReversedPhrases.Add(new Domain.Phrase { Id = 4, OriginalText = "TestPhrase number Four", ReversedText = "ruoF rebmun esarhPtseT", Reversed = new DateTime(2022, 8, 4) });
            context.ReversedPhrases.Add(new Domain.Phrase { Id = 5, OriginalText = "TestPhrase number Five", ReversedText = "eviF rebmun esarhPtseT", Reversed = new DateTime(2022, 8, 5) });
            context.ReversedPhrases.Add(new Domain.Phrase { Id = 6, OriginalText = "TestPhrase number Six", ReversedText = "xiS rebmun esarhPtseT", Reversed = new DateTime(2022, 8, 6) });
            context.SaveChanges();
            return context;
        }
    }
}
