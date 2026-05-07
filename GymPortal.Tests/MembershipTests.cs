using GymPortal.Domain.Entities;
using Xunit;

namespace GymPortal.Tests
{
    public class MembershipTests
    {
        [Fact]
        public void Membership_Should_Be_Active_When_EndDate_Is_Future()
        {
            var membership = new Membership
            {
                EndDate = DateTime.UtcNow.AddDays(10)
            };

            Assert.True(membership.IsActive);
        }

        [Fact]
        public void Membership_Should_Not_Be_Active_When_EndDate_Is_Past()
        {
            var membership = new Membership
            {
                EndDate = DateTime.UtcNow.AddDays(-1)
            };

            Assert.False(membership.IsActive);
        }
    }
}