namespace UserTestingApp.Common.DTOs.Test;

public record IncompleteTestDto(
    long Id, 
    string Name, 
    int AttemptsAllowed
    );
