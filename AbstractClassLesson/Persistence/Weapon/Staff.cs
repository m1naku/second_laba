namespace AbstractClassLesson.Persistence.Weapon;

public class Staff : IWeapon
{
    public double Damage => 8;

    public int Distance => 2;

    public string Name => "Посох";

}