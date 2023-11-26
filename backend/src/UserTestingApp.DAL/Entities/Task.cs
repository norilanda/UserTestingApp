using UserTestingApp.DAL.Entities.Abstract;

namespace UserTestingApp.DAL.Entities;

public class Task : BaseEntity<long>
{
    public long TestId {  get; set; }
    public int Number { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public Test Test { get; set; } = null!;
}
