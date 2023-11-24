using UserTestingApp.BLL.Interfaces;
using UserTestingApp.Common.DTOs.Answer;
using UserTestingApp.Common.DTOs.Test;

namespace UserTestingApp.BLL.Services;

public class TestService : ITestService
{
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

    public Task<TestWithTasksDto> GetTestWithTasksByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<double> PassTestAsync(long testId, long userId, List<AnswerDto> answers)
    {
        throw new NotImplementedException();
    }
}
