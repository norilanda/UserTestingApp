using UserTestingApp.DAL.Entities.Abstract;

namespace UserTestingApp.DAL.Entities;

public class AssignedTest : BaseEntity<long>
{
    public long TestId { get; set; }
    public long UserId { get; set; }
    public double? Mark { get; set; }
    public DateTime? DateCompleted { get; set; }
    public Test Test { get; set; } = null!;
    public User User { get; set; } = null!;
}
