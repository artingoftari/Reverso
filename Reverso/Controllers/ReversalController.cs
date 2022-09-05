using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reverso.Application;
using Reverso.Application.Phrase;
using Reverso.Application.Phrase.ViewModels;
using Reverso.Domain;
using System.Net;
using System.Security.AccessControl;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Reverso.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class ReversalController : ReversoBaseController
    {

        private readonly ILogger<ReversalController> _logger;

        public ReversalController(ILogger<ReversalController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "ReversePhrase")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PhraseViewModel))]
        public async Task<ActionResult<PhraseViewModel>> ReversePhrase(ReversePhraseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet(Name = "GetLatestReversedPhrases")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<PhraseViewModel>))]
        public async Task<ActionResult<List<PhraseViewModel>>> GetLatestReversedPhrases(int page, int size)
        {
            return Ok(await Mediator.Send(new GetLatestReversedPhrasesQuery { Page = page, Size = size }));
        }
    }
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public abstract class ReversoBaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {

            get
            {
                if (_mediator == null)
                {
                    _mediator = HttpContext.RequestServices.GetService<IMediator>();
                }
                return _mediator;
            }
        }
    }
}