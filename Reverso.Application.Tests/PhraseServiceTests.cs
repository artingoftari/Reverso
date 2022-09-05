using Moq;
using Reverso.Application.Interfaces;
using Reverso.Application.Phrase;
using Reverso.Application.Tests.Infrastructure;
using Reverso.Base.Test;
using Reverso.Persistence;
using System.Linq;
using System.Threading;
using Xunit;

namespace Reverso.Application.Phrase.Tests
{
    public class PhraseServiceTests
    {
        private readonly ReversePhraseCommandHandler commandHandler;
        private ReversoDbContext context = TestContextFactory.CreateMockContext();
        public PhraseServiceTests()
        {
            commandHandler = new ReversePhraseCommandHandler(context);
        }
        [Fact]
        public async void HandleReversePhraseCommand_ReceivesPhrase_SavesToDb()
        {
            ReversePhraseCommand command = new ReversePhraseCommand { PhraseToReverse = TestPhrases.MultiWordPhrase };

            await commandHandler.Handle(command, CancellationToken.None);

            Assert.True(context.ReversedPhrases.Any(rp => rp.ReversedText == TestPhrases.ReversedMultiWordPhrase));
        }
    }
}