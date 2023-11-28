using UserTestingApp.DAL.Entities.Abstract;

namespace UserTestingApp.DAL.Entities;

public class User : BaseEntity<long>
{
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public ICollection<AssignedTest> Tests { get; set; } = new List<AssignedTest>();
}
