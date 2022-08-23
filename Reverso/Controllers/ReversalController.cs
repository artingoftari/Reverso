using Microsoft.AspNetCore.Mvc;
using Reverso.Application;

namespace Reverso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReversalController : ControllerBase
    {

        private readonly ILogger<ReversalController> _logger;

        public ReversalController(ILogger<ReversalController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "ReversePhrase")]
        public string ReversePhrase(string phraseToReverse)
        {
            return new PhraseReverser(new char[] { ',','.' }).ReversePhrase(phraseToReverse);
        }
    }
}