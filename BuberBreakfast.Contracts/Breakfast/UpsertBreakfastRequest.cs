namespace BuberBreakfast.Contracts.Breakfast;
public record UpsertBreakfastResquest
(
    string Name,
    string Description,
    DateTime startDateTime,
    DateTime endDateTime,
    List<string> savory,
    List<string> sweet
);