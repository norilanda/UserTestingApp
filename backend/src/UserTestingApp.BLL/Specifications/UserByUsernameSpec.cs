using Ardalis.Specification;
using UserTestingApp.DAL.Entities;

namespace UserTestingApp.BLL.Specifications;

public class UserByUsernameSpec : Specification<User>
{
    public UserByUsernameSpec(string username)
    {
        Query
            .Where(u  => u.Username == username);
    }
}
