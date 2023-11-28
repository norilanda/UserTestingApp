using UserTestingApp.BLL.Exceptions;
using UserTestingApp.BLL.Interfaces;
using UserTestingApp.BLL.Specifications;
using UserTestingApp.BLL.Specifications.UserTests;
using UserTestingApp.Common.DTOs.Answer;
using UserTestingApp.Common.DTOs.Test;
using UserTestingApp.DAL.Entities;
using UserTestingApp.DAL.Interfaces;

namespace UserTestingApp.BLL.Services;

public class TestService : ITestService
{
    private readonly IGenericRepository<Test> _testRepository;
    private readonly IGenericRepository<AssignedTest> _assignedTestRepository;
    private readonly IGenericRepository<DAL.Entities.Task> _taskRepository;

    public TestService(IGenericRepository<Test> testRepository, IGenericRepository<DAL.Entities.Task> taskRepository,  IGenericRepository<AssignedTest> assignedTestRepository)
    {
        _testRepository = testRepository;
        _taskRepository = taskRepository;
        _assignedTestRepository = assignedTestRepository;
    }

    public async Task<IEnumerable<TestDto>> GetAssignedTestsForUserAsync(long userId)
    {
        var specification = new UserAssignedTestsSpec(userId);
        var assignedTests = await _assignedTestRepository.ListAsync(specification);

        return assignedTests;
    }

    public async Task<IEnumerable<TestDto>> GetCompletedTestsForUserAsync(long userId)
    {
        var specification = new UserCompletedTestsSpec(userId);
        var completedTests = await _assignedTestRepository.ListAsync(specification);

        return completedTests;
    }

    public async Task<IEnumerable<IncompleteTestDto>> GetIncompleteTestsForUserAsync(long userId)
    {
        var specification = new UserIncompleteTestsSpec(userId);
        var incompleteTests = await _assignedTestRepository.ListAsync(specification);

        return incompleteTests;
    }

    public async Task<TestWithTasksDto> GetTestWithTasksByIdAsync(long id)
    {
        var specification = new TestWithTasksSpec(id);
        var testWithTasks = await _testRepository.FirstOrDefaultAsync(specification);

        if ( testWithTasks == null)
        {
            throw ResponseException.NotFound();
        }

        return testWithTasks;
    }

    public async Task<double> PassTestAsync(long testId, long userId, List<AnswerDto> answers)
    {
        var assingedTestSpec = new UserAssignedTestByIdSpec(userId, testId);
        var assignedTest = await _assignedTestRepository.FirstOrDefaultAsync(assingedTestSpec);

        if (assignedTest == null)
            throw ResponseException.Forbidden();

        var tasksSpec = new TasksByTestIdSpec(testId);
        var tasks = await _taskRepository.ListAsync(tasksSpec);

        double mark = CalculateMark(tasks, answers);

        assignedTest.Mark = mark;
        assignedTest.DateCompleted = DateTime.UtcNow;

        await _assignedTestRepository.UpdateAsync(assignedTest);

        return mark;
    }

    private double CalculateMark(List<DAL.Entities.Task> tasks, List<AnswerDto> answers)
    {
        double mark = 0;
        AnswerDto? currentAnswer;
        foreach (var task in tasks)
        {
            currentAnswer = answers.FirstOrDefault(a => a.TaskId == task.Id);

            if (currentAnswer == null)
                throw ResponseException.BadRequest();

            if (currentAnswer.Answer.Equals(task.Answer))
                mark++;
        }

        return mark;
    }
}
