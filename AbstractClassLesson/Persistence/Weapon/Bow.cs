namespace AbstractClassLesson.Persistence.Weapon;

public class Bow : IWeapon
{
    public double Damage => 10;

    public int Distance => 1;

    public string Name => "Лук";

}