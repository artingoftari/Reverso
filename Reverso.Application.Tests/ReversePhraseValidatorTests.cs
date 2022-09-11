using Reverso.Application.Configuration;
using Reverso.Application.Phrase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reverso.Application.Tests
{
    public class ReversePhraseValidatorTests
    {
        ReversePhraseConfiguration config;
        ReversePhraseValidator validator;
        public ReversePhraseValidatorTests()
        {
            config = new ReversePhraseConfiguration { MaxInputStringLength = 10 };
            validator = new ReversePhraseValidator(config);
        }
        [Fact]
        public void Validate_TextToReverseExceedsMaxStringLength_MarksInvalid()
        {
            ReversePhraseCommand command = new ReversePhraseCommand { PhraseToReverse = "Lorem ipsum dolor sit amet" };

            PhraseValidation result = validator.Validate(command);

            Assert.False(result.Valid);
        }
        [Fact]
        public void Validate_TextToReverseIsNull_MarksInvalid()
        {
            ReversePhraseCommand command = new ReversePhraseCommand();

            PhraseValidation result = validator.Validate(command);

            Assert.False(result.Valid);
        }
    }
}
