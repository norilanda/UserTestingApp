using UserTestingApp.Common.DTOs.Task;

namespace UserTestingApp.Common.DTOs.Test;

public record TestWithTasksDto(
    long Id, 
    string Name,
    List<TaskDto> Tasks
    );
