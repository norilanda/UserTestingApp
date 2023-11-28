using FakeItEasy;
using System.Net;
using UserTestingApp.BLL.Exceptions;
using UserTestingApp.BLL.Services;
using UserTestingApp.BLL.Specifications;
using UserTestingApp.BLL.Specifications.UserTests;
using UserTestingApp.Common.DTOs.Answer;
using UserTestingApp.DAL.Entities;
using UserTestingApp.DAL.Interfaces;
using Xunit;

using Task = System.Threading.Tasks.Task;

namespace BLL.Tests.Unit.TestServiceTests;

public class PassTestAsyncTests
{
    private IGenericRepository<Test> _testRepositoryDummy;
    private IGenericRepository<UserTestingApp.DAL.Entities.Task> _taskRepositoryDummy;
    private IGenericRepository<AssignedTest> _assignedTestRepositoryDummy;

    public PassTestAsyncTests()
    {
        _testRepositoryDummy = A.Dummy<IGenericRepository<Test>>();
        _taskRepositoryDummy = A.Dummy<IGenericRepository<UserTestingApp.DAL.Entities.Task>>();
        _assignedTestRepositoryDummy = A.Dummy<IGenericRepository<AssignedTest>>();
    }

    [Fact]
    public async Task PassTestAsync_WhenTestNotAssignedToUser_ShouldThrow()
    {
        // Arrange
        var answers = new List<AnswerDto>();
        var assignedTestRepositoryStub = GetAssignedTestRepositoryStub(false);

        var testService = new TestService(_testRepositoryDummy, _taskRepositoryDummy, assignedTestRepositoryStub);

        // Act
        var act = () => testService.PassTestAsync(1, 1, answers);
        
        // Assert
        var ex = await Assert.ThrowsAsync<ResponseException>(act);
        Assert.Equal(HttpStatusCode.Forbidden, ex.StatusCode);
    }

    [Theory]
    [MemberData(nameof(CreateNotAllAnswers))]
    public async Task PassTestAsync_WhenSomeAnswersAreMissing_ShouldThrow(List<AnswerDto> answers)
    {
        // Arrange 
        var assignedTestRepositoryStub = GetAssignedTestRepositoryStub(true);
        var taskRepositoryStub = GetTaskRepositoryStub();

        var testService = new TestService(_testRepositoryDummy, taskRepositoryStub, assignedTestRepositoryStub);

        // Act
        var act = () => testService.PassTestAsync(1, 1, answers);

        // Assert
        var ex = await Assert.ThrowsAsync<ResponseException>(act);
        Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
    }

    [Theory]
    [MemberData(nameof(CreateAllAnswers))]
    public async Task PassTestAsync_WhenAllAnswersPresent_ShouldReturnSpecifiedMark(List<AnswerDto> answers, double mark)
    {
        // Arrange 
        var assignedTestRepositoryStub = GetAssignedTestRepositoryStub(true);
        var taskRepositoryStub = GetTaskRepositoryStub();

        var testService = new TestService(_testRepositoryDummy, taskRepositoryStub, assignedTestRepositoryStub);

        // Act
        double markActual = await testService.PassTestAsync(1, 1, answers);

        // Assert
        Assert.Equal(markActual, mark);
    }

    private static IGenericRepository<AssignedTest> GetAssignedTestRepositoryStub(bool isTestAssignedToUser)
    {
        var assignedTest = isTestAssignedToUser ? new AssignedTest()
        {
            Id = 1,
            TestId = 1,
            UserId = 1,
            Mark = null,
            DateCompleted = null
        }
        : null;

        var assignedTestRepositoryStub = A.Fake<IGenericRepository<AssignedTest>>();

        A.CallTo(() => assignedTestRepositoryStub.FirstOrDefaultAsync(A<UserAssignedTestByIdSpec>._, A<CancellationToken>._))
            .Returns(assignedTest);

        return assignedTestRepositoryStub;
    }

    private static IGenericRepository<UserTestingApp.DAL.Entities.Task> GetTaskRepositoryStub()
    {
        var tasks = CreateTaskList();
        var taskRepositoryStub = A.Fake<IGenericRepository<UserTestingApp.DAL.Entities.Task>>();

        A.CallTo(() => taskRepositoryStub.ListAsync(A<TasksByTestIdSpec>._, A<CancellationToken>._))
            .Returns(tasks);

        return taskRepositoryStub;
    }

    private static List<UserTestingApp.DAL.Entities.Task> CreateTaskList()
    {
        return new List<UserTestingApp.DAL.Entities.Task>
        {
            new() {
                Id = 1,
                TestId = 1,
                Number = 1,
                Question = "2 + 2 = ",
                Answer = "4"
            },
            new() {
                Id = 2,
                TestId = 1,
                Number = 2,
                Question = "2 - 2 = ",
                Answer = "0"
            },
        };
    }

    public static IEnumerable<object[]> CreateNotAllAnswers()
    {
        yield return new object[]
        {
            new List<AnswerDto>()
        };

        yield return new object[] 
        {
            new List<AnswerDto>
            {
                new (1, "4")
            }
        };
    }

    public static IEnumerable<object[]> CreateAllAnswers()
    {
        yield return new object[]
        {
            new List<AnswerDto>
            {
                new (1, "4"),
                new (2, "0")
            },
            2
        };

        yield return new object[]
        {
            new List<AnswerDto>
            {
                new (1, "4"),
                new (2, "4")
            },
            1
        };

        yield return new object[]
        {
            new List<AnswerDto>
            {
                new (1, "-1"),
                new (2, "-1")
            },
            0
        };
    }
}
