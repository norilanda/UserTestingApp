using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTestingApp.Common.DTOs.Answer;
using UserTestingApp.Common.DTOs.Test;

namespace UserTestingApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TestsController : ControllerBase
{
    [HttpGet("{id}")]
    public Task<ActionResult<TestWithTasksDto>> Get(long id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("assigned")]
    public Task<ActionResult<IEnumerable<TestDto>>> GetAssignedTests()
    {
        throw new NotImplementedException();
    }

    [HttpGet("incomplete")]
    public Task<ActionResult<IEnumerable<IncompleteTestDto>>> GetIncompleteTests() 
    { 
        throw new NotImplementedException(); 
    }

    [HttpGet("completed")]
    public Task<ActionResult<IEnumerable<TestDto>>> GetCompletedTests() 
    { 
        throw new NotImplementedException(); 
    }

    [HttpPost("{id}/pass")]
    public Task<ActionResult<double>> Pass([FromBody] List<AnswerDto> answers)
    {
        throw new NotImplementedException();
    }
}
