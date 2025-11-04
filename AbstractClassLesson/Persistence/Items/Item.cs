namespace AbstractClassLesson.Persistence.Items;

public class Item
{
    public Guid Id { get; protected set; }
    
    public double Weight { get; protected set; }
    
    public double InitialPrice { get; protected set; }

}