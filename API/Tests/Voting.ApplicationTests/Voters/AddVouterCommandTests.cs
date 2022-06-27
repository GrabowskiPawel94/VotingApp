using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Voting.Application.Voters.Commands.AddVoter;

namespace Voting.ApplicationTests.Voters
{
    public class AddVouterCommandTests : BaseTestFixture
    {
        private AddVoterCommandValidator _validator;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _validator = new AddVoterCommandValidator();
        }

        [Test]
        public void Validator_TryAddNewUserWithoutName_ThrowsValidationException()
        {
            var result = _validator.TestValidate(new AddVoterCommand(null));

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public void Validator_TryAddNewUserWithEmptyName_ThrowsValidationException()
        {
            var result = _validator.TestValidate(new AddVoterCommand(string.Empty));

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public async Task RunCommand_TryAddCorrectVoter_AddsNewVoter()
        {
            var command = new AddVoterCommand("Test");
            var sut = new AddVoterCommandHandler(_voteDbContext);

            await sut.Handle(command, new CancellationToken());
            var voter = await _voteDbContext.Voters
                .FirstOrDefaultAsync(x => x.Name == "Test");

            Assert.IsNotNull(voter);
            Assert.That(voter?.Name, Is.EqualTo("Test"));
        }
    }
}
