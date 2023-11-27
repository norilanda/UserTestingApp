using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTestingApp.BLL.Interfaces;
using UserTestingApp.Common.DTOs.Answer;
using UserTestingApp.Common.DTOs.Test;

namespace UserTestingApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TestsController : ControllerBase
{
    private readonly ITestService _testService;
    private readonly IUserIdGetter _userIdGetter;

    public TestsController(ITestService testService, IUserIdGetter userIdGetter)
    {
        _testService = testService;
        _userIdGetter = userIdGetter;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TestWithTasksDto>> Get(long id)
    {
        var testWithTasks = await _testService.GetTestWithTasksByIdAsync(id);
        return Ok(testWithTasks);
    }

    [HttpGet("assigned")]
    public async Task<ActionResult<IEnumerable<TestDto>>> GetAssignedTests()
    {
        var userId = _userIdGetter.GetCurrentUserId();
        var assignedTests = await _testService.GetAssignedTestsForUserAsync(userId);

        return Ok(assignedTests);
    }

    [HttpGet("incomplete")]
    public async Task<ActionResult<IEnumerable<IncompleteTestDto>>> GetIncompleteTests() 
    { 
        var userId = _userIdGetter.GetCurrentUserId();
        var incompleteTests = await _testService.GetIncompleteTestsForUserAsync(userId);

        return Ok(incompleteTests);
    }

    [HttpGet("completed")]
    public async Task<ActionResult<IEnumerable<TestDto>>> GetCompletedTests() 
    { 
        var userId = _userIdGetter.GetCurrentUserId();
        var completedTests = await _testService.GetCompletedTestsForUserAsync(userId);

        return Ok(completedTests);
    }

    [HttpPost("{id}/pass")]
    public async Task<ActionResult<double>> Pass(long id, [FromBody] List<AnswerDto> answers)
    {
        var userId = _userIdGetter.GetCurrentUserId();
        double mark = await _testService.PassTestAsync(id, userId, answers);

        return Ok(mark);
    }
}
