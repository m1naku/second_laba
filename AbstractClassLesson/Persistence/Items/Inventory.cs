namespace AbstractClassLesson.Persistence.Items;
using AbstractClassLesson.Persistence.Weapon;

public class Inventory (int size)
{
    private readonly List<IWeapon> _weapons = [];

    public IWeapon? this[int position] => _weapons[position];

    public IWeapon? GetWeapon(int position)
    {
        return _weapons.Count < position ? null : _weapons[position];
    }

    public bool AddNewWeapon(IWeapon? newWeapon)
    {
        if (_weapons.Contains(newWeapon))
            return false;

        _weapons.Add(newWeapon);

        return true;
    }

    public bool RemoveWeaponFromPos(int position)
    {
        if (_weapons.Count < position)
            return false;

        _weapons.RemoveAt(position);
        return true;
    }
}
