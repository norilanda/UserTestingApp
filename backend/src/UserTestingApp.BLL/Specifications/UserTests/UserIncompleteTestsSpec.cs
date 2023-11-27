using Ardalis.Specification;
using UserTestingApp.Common.DTOs.Test;
using UserTestingApp.DAL.Entities;

namespace UserTestingApp.BLL.Specifications;

public class UserIncompleteTestsSpec : Specification<AssignedTest, IncompleteTestDto>
{
    public UserIncompleteTestsSpec(long userId)
    {
        Query
            .Where (a => a.UserId == userId && a.Mark == null)
            .Include(a => a.Test);

        Query.Select(a => new IncompleteTestDto(a.Test.Id, a.Test.Name));
    }
}