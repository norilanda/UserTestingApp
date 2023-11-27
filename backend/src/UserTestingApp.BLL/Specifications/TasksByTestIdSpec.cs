using Ardalis.Specification;
using Task = UserTestingApp.DAL.Entities.Task;

namespace UserTestingApp.BLL.Specifications;

public class TasksByTestIdSpec : Specification<Task>
{
    public TasksByTestIdSpec(long testId)
    {
        Query.Where(t => t.TestId == testId);   
    }
}
