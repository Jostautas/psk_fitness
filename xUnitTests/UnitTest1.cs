using Bunit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Data;

namespace xUnitTests;

public class UnitTest1(ApplicationDbContextFixture fixture) : TestContext, IClassFixture<ApplicationDbContextFixture>
{
    private readonly ApplicationDbContext _context = fixture.Context;

    [Fact]
    public void Test1()
    {
    }

    [Fact]
    public async Task AddTopicAndLinkToUserAsFriend()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        // Using a string userId for the existing ApplicationUser as per Identity's default
        var userId = "existing-user-id";
        var applicationUser = new ApplicationUser { Id = userId };
        var topic = new Topic { Title = "New Topic", ApplicationUserId = applicationUser.Id, ApplicationUser = applicationUser };
        var topicFriend = new TopicFriend { ApplicationUserId = userId, ApplicationUser = applicationUser, ReadAndWrite = true, TopicId = topic.Id, Topic = topic };

        // Act
        using (var context = new ApplicationDbContext(options))
        {
            context.Users.Add(applicationUser);
            context.Topics.Add(topic);
            await context.SaveChangesAsync();

            topicFriend.TopicId = topic.Id;

            context.TopicFriends.Add(topicFriend);
            await context.SaveChangesAsync();
        }

        // Assert
        using (var context = new ApplicationDbContext(options))
        {
            var addedTopic = await context.Topics.FirstOrDefaultAsync(t => t.Title == topic.Title);
            var linkedTopicFriend = await context.TopicFriends
                .FirstOrDefaultAsync(tf => tf.TopicId == addedTopic.Id && tf.ApplicationUserId == userId);

            Assert.NotNull(addedTopic);
            Assert.NotNull(linkedTopicFriend);
            Assert.Equal(userId, linkedTopicFriend.ApplicationUserId);
            Assert.Equal(addedTopic.Id, linkedTopicFriend.TopicId);
            Assert.True(linkedTopicFriend.ReadAndWrite);
        }
    }
}