using FakeItEasy;
using System.Net;
using UserTestingApp.BLL.Exceptions;
using UserTestingApp.BLL.Services;
using UserTestingApp.BLL.Specifications;
using UserTestingApp.Common.DTOs.Task;
using UserTestingApp.Common.DTOs.Test;
using UserTestingApp.DAL.Entities;
using UserTestingApp.DAL.Interfaces;
using Xunit;

using Task = System.Threading.Tasks.Task;

namespace BLL.Tests.Unit.TestServiceTests;

public class GetTestWithTasksByIdAsyncTests
{
    private IGenericRepository<UserTestingApp.DAL.Entities.Task> _taskRepositoryDummy;
    private IGenericRepository<AssignedTest> _assignedTestRepositoryDummy;

    public GetTestWithTasksByIdAsyncTests()
    {
        _taskRepositoryDummy = A.Dummy<IGenericRepository<UserTestingApp.DAL.Entities.Task>>();
        _assignedTestRepositoryDummy = A.Dummy<IGenericRepository<AssignedTest>>();
    }

    [Fact]
    public async Task GetTestWithTasksByIdAsync_WhenTestExists_ShouldReturnFoundTest()
    {
        // Arrange
        var testDto = new TestWithTasksDto(2, "Test 1", new List<TaskDto>
        {
            new( 1, 1, "How are you?"),
        });

        var testRepositoryStub = A.Fake<IGenericRepository<Test>>();
        A.CallTo(() => testRepositoryStub.FirstOrDefaultAsync(
            A<TestWithTasksSpec>._, A<CancellationToken>._))
            .Returns(testDto);

        var testService = new TestService(testRepositoryStub, _taskRepositoryDummy, _assignedTestRepositoryDummy);

        // Act
        var foundTestDto = await testService.GetTestWithTasksByIdAsync(testDto.Id);

        // Assert
        Assert.Equal(testDto, foundTestDto);
    }

    [Fact]
    public async Task GetTestWithTasksByIdAsync_WhenTestNotExists_ShouldThrow()
    {
        // Arrange
        TestWithTasksDto? testDto = null;
        long testIdToSearch = 1;

        var testRepositoryStub = A.Fake<IGenericRepository<Test>>();
        A.CallTo(() => testRepositoryStub.FirstOrDefaultAsync(
            A<TestWithTasksSpec>._, A<CancellationToken>._))
            .Returns(testDto);

        var testService = new TestService(testRepositoryStub, _taskRepositoryDummy, _assignedTestRepositoryDummy);

        // Act
        var act = async () => await testService.GetTestWithTasksByIdAsync(testIdToSearch);

        // Assert
        var ex = await Assert.ThrowsAsync<ResponseException>(act);
        Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
    }
}
