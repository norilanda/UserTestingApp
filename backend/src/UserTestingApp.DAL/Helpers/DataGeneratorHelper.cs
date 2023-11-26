using Bogus;
using UserTestingApp.Common.Security;
using UserTestingApp.DAL.Entities;

namespace UserTestingApp.DAL.Helpers;

public static class DataGeneratorHelper
{
    private const int _testNumber = 10;

    private const int _minTaskNumberPerTest = 1;
    private const int _maxTaskNumberPerTest = 3;

    private const int _userNumber = 3;

    private const int _minTestNumberPerUser = 3;
    private const int _maxTestNumberPerUser = 7;

    public static IEnumerable<AssignedTest> GenerateAssignedTests()
    {
        var random = new Random();

        int count = 0;
        int currentUserId = 0;

        List<AssignedTest> assignedTests = new();

        while (currentUserId < _userNumber)
        {
            var testNumberForCurentUser = random.Next(_minTestNumberPerUser, _maxTestNumberPerUser);
            int testCount = 0;

            var assignedTestFaker = new Faker<AssignedTest>()
                .RuleFor(t => t.Id, _ => count++)
                .RuleFor(t => t.TestId, _ => testCount++)
                .RuleFor(t => t.UserId, _ => currentUserId)
                .RuleFor(t => t.Mark, f => f.Random.Number(1, 3))
                .RuleFor(t => t.DateCompleted, f => f.Date.Past());

            assignedTests.AddRange(assignedTestFaker.Generate(testNumberForCurentUser));

            currentUserId++;
        }

        return assignedTests;
    }

    public static IEnumerable<Entities.Task> GenerateTasks()
    {
        var random = new Random();

        int count = 0;
        int currentTestId = 0;

        List<Entities.Task> Tasks = new();

        while (currentTestId < _testNumber)
        {
            var tasktNumberForCurentTest = random.Next(_minTaskNumberPerTest, _maxTaskNumberPerTest);
            int currentTaskNumber = 1;

            var taskFaker = new Faker<Entities.Task>() 
                .RuleFor(t => t.Id, _ => count++)
                .RuleFor(t => t.TestId, _ => currentTestId)
                .RuleFor(t => t.Number, _ => currentTaskNumber++)
                .RuleFor(t => t.Question, _ => $"{count} + 1 =")
                .RuleFor(t => t.Answer, _ => $"{count + 1}");

            Tasks.AddRange(taskFaker.Generate(tasktNumberForCurentTest));

            currentTestId++;
        }

        return Tasks;
    }

    public static IEnumerable<Test> GenerateTests()
    {
        int count = 0;

        var testFaker = new Faker<Test>()
            .RuleFor(t => t.Id, _ =>  count++)
            .RuleFor(t => t.Name, f => f.Lorem.Word());

        return testFaker.Generate(_testNumber);
    }

    public static IEnumerable<User> GenerateUsers()
    {
        int count = 0;

        var userFaker = new Faker<User>()
            .RuleFor(u => u.Id, _ => count++)
            .RuleFor(u => u.Username, f => f.Person.UserName)
            .RuleFor(u => u.Salt, Convert.ToBase64String(PasswordHasherHelper.GenerateSalt()))
            .RuleFor(u => u.PasswordHash, 
                (_, u) => PasswordHasherHelper.HashPassword($"{u.Username}", Convert.FromBase64String(u.Salt)));

        return userFaker.Generate(_userNumber);
    }
}
