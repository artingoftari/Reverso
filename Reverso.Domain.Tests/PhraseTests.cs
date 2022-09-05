using Reverso.Base.Test;

namespace Reverso.Domain.Tests
{
    public class PhraseTests
    {
        [Fact]
        public void ReversePhrase_ReceivesSingleWord_ReversesIt()
        {
            Phrase singleWordPhrase = new Phrase(TestPhrases.SingleWord);

            Assert.Equal(TestPhrases.ReversedWord, singleWordPhrase.ReversedText);
        }
        [Fact]
        public void ReversePhrase_ReceivesMultiWordPhrase_ReversesEachWord()
        {
            Phrase multiWordPhrase = new Phrase(TestPhrases.MultiWordPhrase);
            Assert.Equal(TestPhrases.ReversedMultiWordPhrase, multiWordPhrase.ReversedText);
        }
        [Fact]
        public void ReversePhrase_ReceivesEmptyString_ReturnsEmptyString()
        {
            Phrase emptyPhrase = new Phrase(string.Empty);

            Assert.Equal(string.Empty, emptyPhrase.ReversedText);
        }
        [Fact]
        public void ReversePhrase_ReceivesSpace_ReturnsEmptyString()
        {
            Phrase phraseWithOnlySpace = new Phrase(" ");

            Assert.Equal(string.Empty, phraseWithOnlySpace.ReversedText);
        }
        [Fact]
        public void ReversePhrase_ReceivesPhraseWithRecurringWords_ReversesAllWords()
        {
            Phrase multiWordPhraseWithRecurringWords = new Phrase(TestPhrases.MultiWordPhraseWithRecurringWords);

            Assert.Equal(TestPhrases.ReversedMultiWordPhraseWithRecurringWords, multiWordPhraseWithRecurringWords.ReversedText);
        }
        [Fact]
        public void ReversePhrase_ConfiguredForPeriodSeparator_KeepsPeriodPositionsAndReversesOtherSymbols()
        {

            Phrase reversalResultWithPeriod = new Phrase(TestPhrases.MultiWordPhraseWithPeriod, new char[] { ' ', '.' });
            Phrase reversalResultWithPeriodAndSemicolon = new Phrase(TestPhrases.MultiWordPhraseWithPeriodAndSemicolon, new char[] { ' ', '.' });

            Assert.Equal(TestPhrases.ReversedMultiWordPhraseWithPeriod, reversalResultWithPeriod.ReversedText);
            Assert.Equal(TestPhrases.ReversedMultiWordPhraseWithPeriodAndSemicolon, reversalResultWithPeriodAndSemicolon.ReversedText);
        }
        [Fact]
        public void ReversePhrase_ReceivesPhrase_KeepsCase()
        {

            Phrase reversalResultWithPeriod = new Phrase(TestPhrases.MultiWordPhraseWithDifferentCases, new char[] { ' ', '.' });

            Assert.Equal(TestPhrases.ReversedMultiWordPhraseWithDifferentCases, reversalResultWithPeriod.ReversedText);
        }
    }
}