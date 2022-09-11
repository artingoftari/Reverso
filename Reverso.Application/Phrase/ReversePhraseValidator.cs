using Reverso.Application.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Application.Phrase
{
    public class ReversePhraseValidator
    {
        ReversePhraseConfiguration _config;
        public ReversePhraseValidator(ReversePhraseConfiguration config)
        {
            _config = config;
        }
        public PhraseValidation Validate(ReversePhraseCommand command)
        {
            PhraseValidation validation = new PhraseValidation { Valid = true };
            if (command.PhraseToReverse == null)
            {
                validation.Valid = false;
                validation.Message = "PhraseToReverse was null";
                return validation;
            }
            if (command.PhraseToReverse?.Length >= _config.MaxInputStringLength)
            {
                validation.Valid = false;
                validation.Message = $"PhraseToReverse exceeded maximun input string length ({_config.MaxInputStringLength})";
            }
            return validation;
        }
    }
    public class PhraseValidation
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
    }
    
}
