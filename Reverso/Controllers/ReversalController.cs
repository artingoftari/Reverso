using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
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
    public class ReversalController : ReversoBaseController
    {

        private readonly ILogger<ReversalController> _logger;

        public ReversalController(ILogger<ReversalController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Reverse phrase
        /// </summary>
        /// <remarks>
        /// Reverses each word of the input string. Max length follows configuration value. Every word is reversed separately but keeps its position in the string as a whole. Special characters are treated like spaces.
        /// </remarks>
        /// <param name="command">Input string to reverse.</param>
        /// <returns>An object containing the reversed text, the original and a timestamp</returns>
        [HttpPost(Name = "ReversePhrase")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PhraseViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<PhraseViewModel>> ReversePhrase(ReversePhraseCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (ArgumentException ex)
            {
                return new ObjectResult(new ProblemDetails
                {
                    Title = "ArgumentException",
                    Detail = ex.Message,
                    Status = 400,
                    Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/400",
                    Instance = "/api/v1/ReversePhrase"
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new ProblemDetails
                {
                    Title = "Exception",
                    Detail = ex.Message,
                    Status = 500,
                    Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500",
                    Instance = "/api/v1/ReversePhrase"
                });
            }
        }
        /// <summary>
        /// Get latest reverse phrases
        /// </summary>
        /// <remarks>
        /// Gets the latest reversed phrases from the database. Paginated.
        /// </remarks>
        /// <param name="page">Defaults to 1.</param>
        /// <param name="size">Defaults to 5. Max 50.</param>
        /// <returns>A list of objects containing the reversed text, the original and a timestamp</returns>
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