using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using Voting.Persistence;

namespace Voting.ApplicationTests
{
    public abstract class BaseTestFixture
    {
        protected VoteDbContext _voteDbContext;
        [SetUp]
        public virtual void Setup()
        {
            var options = new DbContextOptionsBuilder<VoteDbContext>()
                .UseInMemoryDatabase($"VotingAppTets_{DateTime.Now.Ticks}")
                .Options;

            _voteDbContext = new VoteDbContext(options);
        }

        [TearDown]
        public virtual void TearDown()
        {
            _voteDbContext.Dispose();
            _voteDbContext = null;
        }
    }
}