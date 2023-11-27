using Ardalis.Specification;
using UserTestingApp.Common.DTOs.Test;
using UserTestingApp.DAL.Entities;

namespace UserTestingApp.BLL.Specifications.UserTests;

public class UserAssignedTestsSpec : Specification<AssignedTest, TestDto>
{
    public UserAssignedTestsSpec(long userId)
    {
        Query
            .Where(a => a.UserId == userId)
            .Include(a => a.Test);

        Query.Select(a => new TestDto(a.Test.Id, a.Test.Name, a.Mark));
    }
}

public class UserAssignedTestByIdSpec : Specification<AssignedTest>
{
    public UserAssignedTestByIdSpec(long userId, long testId)
    {
        Query
            .Where(a => a.UserId == userId && a.TestId == testId);
    }
}
