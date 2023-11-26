using Ardalis.Specification;
using UserTestingApp.Common.DTOs.Task;
using UserTestingApp.Common.DTOs.Test;
using UserTestingApp.DAL.Entities;

namespace UserTestingApp.BLL.Specifications;
public class TestWithTasksSpecification : Specification<Test, TestWithTasksDto>
{
    public TestWithTasksSpecification(long testId)
    {
        Query
            .Where(test => test.Id == testId)
            .Include(test => test.Tasks)
            ;

        Query.Select(t => new TestWithTasksDto(
            t.Id,
            t.Name,
            t.Tasks.Select(task => new TaskDto(
                task.Id,
                task.Number,
                task.Question)).ToList()));
    }
}
