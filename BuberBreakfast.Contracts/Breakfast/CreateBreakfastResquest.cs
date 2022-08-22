namespace BuberBreakfast.Contracts.Breakfast;
public record CreateBreakfastRequest
(
    string Name,
    string Description,
    DateTime startDateTime,
    DateTime endDateTime,
    List<string> savory,
    List<string> sweet
);