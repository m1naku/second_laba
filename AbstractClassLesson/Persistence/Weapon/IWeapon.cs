namespace AbstractClassLesson.Persistence.Weapon;

public interface IWeapon
{
    public string Name { get; }
    
    public double Damage { get; }
    
    //в 4 лабе distance

    public int Distance { get; }
    
}