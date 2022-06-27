using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Voting.Application.Voters.Commands.AddVoter;
using Voting.Application.Voters.Commands.VoteForCandidate;
using Voting.Application.Voters.Queries.GetVotersList;

namespace Voting.Web.API.Controllers
{
    public class VoterController : BaseController
    {
        public VoterController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVoters()
        {
            return Ok(await _mediator.Send(new GetVotersListQuery()));
        }
    

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AddVoter([FromBody]AddVoterCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/vote/{candidateId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> VoteForCandidate(Guid id, Guid candidateId)
        {
            var command = new VoteForCandidateCommand(id, candidateId);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
