namespace BuberBreakfast.Models;
public class Breakfast
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime startDateTime { get; }
    public DateTime endDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> savory { get; }
    public List<string> sweet { get; }

    public Breakfast(
        Guid id,
        string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime, 
        DateTime lastModifiedDateTime, 
        List<string> savory, 
        List<string> sweet)
    {
        Id = id;
        Name = name;
        Description = description;
        this.startDateTime = startDateTime;
        this.endDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        this.savory = savory;
        this.sweet = sweet;
    }

}