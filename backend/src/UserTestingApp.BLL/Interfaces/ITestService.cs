using UserTestingApp.Common.DTOs.Answer;
using UserTestingApp.Common.DTOs.Test;

namespace UserTestingApp.BLL.Interfaces;

public interface ITestService
{
    public Task<TestWithTasksDto> GetTestWithTasksByIdAsync(long id);
    public Task<IEnumerable<TestDto>> GetAssignedTestsForUserAsync(long userId);
    public Task<IEnumerable<IncompleteTestDto>> GetIncompleteTestsForUserAsync(long userId);
    public Task<IEnumerable<TestDto>> GetCompletedTestsForUserAsync(long userId);
    public Task<double> PassTestAsync(long testId, long userId, List<AnswerDto> answers);
}
