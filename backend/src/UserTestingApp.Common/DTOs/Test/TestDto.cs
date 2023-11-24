namespace UserTestingApp.Common.DTOs.Test;

public record TestDto (
    long Id, 
    string Name, 
    int AttemptsAllowed,
    int AttemtsUsed,
    double Mark
    );
