namespace BuberBreakfast.Contracts.Breakfast;

// find out what records are
public record BreakfastResponse
(
    Guid Id,
    string Name,
    string Description,
    DateTime startDateTime,
    DateTime endDateTime,
    DateTime LastModifiedDateTime,
    List<string> savory,
    List<string> sweet
);