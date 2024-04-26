using AutoMapper;
using Bunit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using psk_fitness;
using psk_fitness.Controllers;
using psk_fitness.Data;
using psk_fitness.DTOs;
using psk_fitness.Interfaces;
using psk_fitness.Repositories;

namespace xUnitTests;

public class TopicTest(ApplicationDbContextFixture fixture) : TestContext, IClassFixture<ApplicationDbContextFixture>
{
    private readonly ApplicationDbContext _context = fixture.Context;

    [Fact]
    public void Test1()
    {
    }

    [Fact]
    public async Task CreatedTopicContainsUserId()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var dbContext = new ApplicationDbContext(options);
        IMapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        ITopicRepository repo = new TopicRepository(dbContext, mapper);
        var userId = Guid.NewGuid().ToString();
        var userEmail = "a@b.com";
        var applicationUser = new ApplicationUser { Id = userId, Email = userEmail};
        dbContext.Users.Add(applicationUser);
        await dbContext.SaveChangesAsync();
        await dbContext.SaveChangesAsync();
        var topicTitle = "New Topic";
        var topicDescription = "Heheh";
        var newTopic = new TopicCreateDTO { Title = topicTitle, Description = topicDescription};
        
        // Act
        await repo.CreateTopicAsync(newTopic, userEmail);

        // Assert
        try {
            var addedTopic = await dbContext.Topics.FirstAsync(t => t.ApplicationUserId == userId);
            Assert.Equal(topicTitle, addedTopic.Title);
            Assert.Equal(topicDescription, addedTopic.Description);
            Assert.Equal(userId, addedTopic.ApplicationUserId);
        }
        catch (InvalidOperationException e) {
            Assert.Fail("No topic is found with user id " + userId);
        }
    }
}