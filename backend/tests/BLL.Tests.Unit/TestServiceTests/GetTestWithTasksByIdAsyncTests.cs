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
    private IGenericRepository<User> _userRepositoryDummy;
    private IGenericRepository<AssignedTest> _assignedTestRepositoryDummy;

    public GetTestWithTasksByIdAsyncTests()
    {
        _userRepositoryDummy = A.Dummy<IGenericRepository<User>>();
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

        var testRepository = A.Fake<IGenericRepository<Test>>();
        A.CallTo(() => testRepository.FirstOrDefaultAsync(
            A<TestWithTasksSpecification>._, A<CancellationToken>.Ignored))
            .Returns(testDto);

        var testService = new TestService(testRepository, _userRepositoryDummy, _assignedTestRepositoryDummy);

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

        var testRepository = A.Fake<IGenericRepository<Test>>();
        A.CallTo(() => testRepository.FirstOrDefaultAsync(
            A<TestWithTasksSpecification>._, A<CancellationToken>.Ignored))
            .Returns(testDto);

        var testService = new TestService(testRepository, _userRepositoryDummy, _assignedTestRepositoryDummy);

        // Act
        var act = async () => await testService.GetTestWithTasksByIdAsync(testIdToSearch);

        // Assert
        var ex = await Assert.ThrowsAsync<ResponseException>(act);
        Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
    }
}
