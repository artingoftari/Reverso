using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Application.Phrase
{
    public class ReversePhraseValidator : AbstractValidator<ReversePhraseCommand>
    {
        public ReversePhraseValidator()
        {
            RuleFor(p => p.PhraseToReverse).MaximumLength(300).WithErrorCode("400").WithMessage($"Requested text to reverse exceeds maximum length of 300");
        }
    }
}
