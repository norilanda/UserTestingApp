using Ardalis.Specification;
using UserTestingApp.Common.DTOs.Test;
using UserTestingApp.DAL.Entities;

namespace UserTestingApp.BLL.Specifications;

public class UserCompletedTestsSpec : Specification<AssignedTest, TestDto>
{
    public UserCompletedTestsSpec(long userId)
    {
        Query
            .Where (a => a.UserId == userId && a.Mark != null)
            .Include(a => a.Test);

        Query.Select(a => new TestDto(a.Test.Id, a.Test.Name, a.Mark));
    }
}
