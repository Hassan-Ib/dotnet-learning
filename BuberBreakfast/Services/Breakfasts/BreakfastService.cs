using BuberBreakfast.Models;
namespace BuberBreakfast.Services.Breakfasts;


public class BreakfastService : IBreakfastService
{

    private static readonly Dictionary<Guid , Breakfast> _breakfasts = new();
        
    public void CreateBreakfast(Breakfast breakfast)
    {
        // throw new NotImplementedException();
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public Breakfast GetBreakfast(Guid id)
    {
        // throw new NotImplementedException();
        return _breakfasts[id];
    }

    public List<Breakfast> GetAllBreakfast()
    {
        var breakfasts = new List<Breakfast>();

        foreach (var (key, value) in _breakfasts)
        {
            breakfasts.Add(value);
        }

        return breakfasts;
    }

    public void UpsertBreakfast(Breakfast breakfast)
    {
        
        // throw new NotImplementedException();
            _breakfasts[breakfast.Id] = breakfast;

    }

    public void DeleteBreakfast(Guid id)
    {
        // throw new NotImplementedException();
        _breakfasts.Remove(id);
    }
}