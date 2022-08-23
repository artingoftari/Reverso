using Reverso.Application.Tests.Infrastructure;
using Xunit;

namespace Reverso.Application.Tests
{
    public class PhraseReverserTests
    {
        private readonly PhraseReverser defaultPhraseReverser;
        public PhraseReverserTests()
        {
            defaultPhraseReverser = new PhraseReverser();
        }
        [Fact]
        public void ReversePhrase_ReceivesSingleWord_ReversesIt()
        {
            string reversalResult = defaultPhraseReverser.ReversePhrase(TestPhrases.SingleWord);

            Assert.Equal(TestPhrases.ReversedWord, reversalResult);
        }
        [Fact]
        public void ReversePhrase_ReceivesMultiWordPhrase_ReversesEachWord()
        {
            string reversalResult = defaultPhraseReverser.ReversePhrase(TestPhrases.MultiWordPhrase);

            Assert.Equal(TestPhrases.ReversedThreeWordPhrase, reversalResult);
        }
        [Fact]
        public void ReversePhrase_ReceivesEmptyString_ReturnsEmptyString()
        {
            string reversalResult = defaultPhraseReverser.ReversePhrase(string.Empty);

            Assert.Equal(string.Empty, reversalResult);
        }
        [Fact]
        public void ReversePhrase_ReceivesSpace_ReturnsEmptyString()
        {
            string reversalResult = defaultPhraseReverser.ReversePhrase(" ");

            Assert.Equal(string.Empty, reversalResult);
        }
        [Fact]
        public void ReversePhrase_ReceivesPhraseWithRecurringWords_ReversesAllWords()
        {
            string reversalResult = defaultPhraseReverser.ReversePhrase(TestPhrases.MultiWordPhraseWithRecurringWords);

            Assert.Equal(TestPhrases.ReversedMultiWordPhraseWithRecurringWords, reversalResult);
        }
        [Fact]
        public void ReversePhrase_ConfiguredForPeriodSeparator_KeepsPeriodPositionsAndReversesOtherSymbols()
        {
            PhraseReverser phraseReverserWithNonSpaceSeparators = new PhraseReverser(new char[] { ' ', '.' });
            string reversalResultWithPeriod = phraseReverserWithNonSpaceSeparators.ReversePhrase(TestPhrases.MultiWordPhraseWithPeriod);
            string reversalResultWithPeriodAndSemicolon = phraseReverserWithNonSpaceSeparators.ReversePhrase(TestPhrases.MultiWordPhraseWithPeriodAndSemicolon);

            Assert.Equal(TestPhrases.ReversedMultiWordPhraseWithPeriod, reversalResultWithPeriod);
            Assert.Equal(TestPhrases.ReversedMultiWordPhraseWithPeriodAndSemicolon, reversalResultWithPeriodAndSemicolon);
        }
        [Fact]
        public void ReversePhrase_ReceivesPhrase_KeepsCase()
        {
            PhraseReverser phraseReverserWithNonSpaceSeparators = new PhraseReverser(new char[] { ' ', '.' });
            string reversalResultWithPeriod = phraseReverserWithNonSpaceSeparators.ReversePhrase(TestPhrases.MultiWordPhraseWithDifferentCases);

            Assert.Equal(TestPhrases.ReversedMultiWordPhraseWithDifferentCases, reversalResultWithPeriod);
        }
    }
}