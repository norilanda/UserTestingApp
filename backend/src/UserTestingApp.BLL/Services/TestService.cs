using UserTestingApp.BLL.Exceptions;
using UserTestingApp.BLL.Interfaces;
using UserTestingApp.BLL.Specifications;
using UserTestingApp.Common.DTOs.Answer;
using UserTestingApp.Common.DTOs.Test;
using UserTestingApp.DAL.Entities;
using UserTestingApp.DAL.Interfaces;

namespace UserTestingApp.BLL.Services;

public class TestService : ITestService
{
    private readonly IGenericRepository<Test> _testRepository;
    private readonly IGenericRepository<AssignedTest> _assignedTestRepository;
    private readonly IGenericRepository<User> _userRepository;

    public TestService(IGenericRepository<Test> testRepository, IGenericRepository<User> userRepository,  IGenericRepository<AssignedTest> assignedTestRepository)
    {
        _testRepository = testRepository;
        _userRepository = userRepository;
        _assignedTestRepository = assignedTestRepository;
    }

    public Task<IEnumerable<TestDto>> GetAssignedTestsForUserAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TestDto>> GetCompletedTestsForUserAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IncompleteTestDto>> GetIncompleteTestsForUserAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public async Task<TestWithTasksDto> GetTestWithTasksByIdAsync(long id)
    {
        var specification = new TestWithTasksSpecification(id);
        var testWithTasks = await _testRepository.FirstOrDefaultAsync(specification);

        if ( testWithTasks == null)
        {
            throw ResponseException.NotFound();
        }

        return testWithTasks;
    }

    public Task<double> PassTestAsync(long testId, long userId, List<AnswerDto> answers)
    {
        throw new NotImplementedException();
    }
}
