using Moq;
using Reverso.Application.Configuration;
using Reverso.Application.Phrase;
using Reverso.Application.Tests.Infrastructure;
using Reverso.Base.Test;
using Reverso.Persistence;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace Reverso.Application.Phrase.Tests
{
    public class ReversePhraseCommandHandlerTests
    {
        private readonly ReversePhraseCommandHandler commandHandler;
        private ReversoDbContext context = TestContextFactory.CreateMockContext();
        public ReversePhraseCommandHandlerTests()
        {
            ReversePhraseConfiguration config = new ReversePhraseConfiguration { MaxInputStringLength = 10, ImmovableCharacters = string.Empty };
            commandHandler = new ReversePhraseCommandHandler(context, config);
        }
        [Fact]
        public async void HandleReversePhraseCommand_ReceivesPhrase_SavesToDb()
        {
            ReversePhraseCommand command = new ReversePhraseCommand { PhraseToReverse = TestPhrases.SingleWord };

            await commandHandler.Handle(command, CancellationToken.None);

            Assert.True(context.ReversedPhrases.Any(rp => rp.ReversedText == TestPhrases.ReversedWord));
        }
        [Fact]
        public async void HandleReversePhraseCommand_ReceivesInvalidCommand_ThrowsArgumentException()
        {
            ReversePhraseCommand excessiveLengthCommand = new ReversePhraseCommand { PhraseToReverse = TestPhrases.MultiWordPhrase };
            ReversePhraseCommand nullCommand = new ReversePhraseCommand();

            //await commandHandler.Handle(command, CancellationToken.None);

            await Assert.ThrowsAsync<ArgumentException>(() => commandHandler.Handle(excessiveLengthCommand, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentException>(() => commandHandler.Handle(nullCommand, CancellationToken.None));
        }
    }
}