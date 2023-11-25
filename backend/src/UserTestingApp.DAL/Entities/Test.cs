using UserTestingApp.DAL.Entities.Abstract;

namespace UserTestingApp.DAL.Entities;

public class Test : BaseEntity<long>
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
    public ICollection<AssignedTest> AssignedTests { get; set; } = new List<AssignedTest>();
}
