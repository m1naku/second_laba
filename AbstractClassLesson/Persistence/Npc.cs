

namespace AbstractClassLesson.Persistence;

public abstract class Npc 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public (double x, double y) Position { get; set; } = (0, 0);
    
    public string Name { get; protected set; }

    public int Level { get; set; } = 1;

    public double HealthPoints { get; set; } = 100.0;

    public double ExpGranted { get; protected set; } = 30.0;
    
    public override string ToString()
    {
        return $"Object:{Id.ToString()} Name:{Name}";
    }
    
    public virtual double GetExp()
    {
        if (!(HealthPoints == 0 | ExpGranted != 0))
            throw new MethodAccessException("Нельзя получить опыт за живого Npc!");

        var expForGet = ExpGranted;
        ExpGranted = 0;
        return expForGet;
    }
    
    public bool IsDead()
    {
        return HealthPoints <= 0;
    }

}