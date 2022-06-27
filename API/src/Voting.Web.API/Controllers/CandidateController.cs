using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Voting.Application.Candidates.Commands.AddCandidate;
using Voting.Application.Candidates.Queries.GetCandidatesList;

namespace Voting.Web.API.Controllers
{
    public class CandidateController : BaseController
    {
        public CandidateController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCandidates()
        {
            return Ok(await _mediator.Send(new GetCandidatesListQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AddCandidate([FromBody] AddCandidateCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
