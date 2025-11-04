using AbstractClassLesson.Game.Logs;
using AbstractClassLesson.Persistence;
using AbstractClassLesson.Persistence.Items;
using AbstractClassLesson.Persistence.Weapon;

namespace AbstractClassLesson.Persistence;

public class Player
{
    private readonly Inventory _inventory = new Inventory(20);
    
    public Player(string name)
    {
        Username = name;
        // Добавляем стартовое оружие
        _inventory.AddNewWeapon(new Bow());
        _inventory.AddNewWeapon(new Staff());
        _inventory.AddNewWeapon(new Sword());
        
    }
    
    private double _damagePoints = 50;
    
    private double _healthPoints = 100.0;

    private int _level = 1;

    private double _experience = 0;
    
    private IWeapon? _currentWeapon;
    
    public int Distance { get; private set; }
    
    public double DamageInfo { get; set; }

    public int Kills { get; set; } 
    
    public (double x, double y) Position { get; set; } = (0, 0);
    
    public int Level => _level;
    
    public double BaseDamage => _damagePoints;
    public double WeaponDamage => _currentWeapon?.Damage ?? 0;
    public double TotalDamage => BaseDamage + WeaponDamage;

    public IWeapon? Weapon => _currentWeapon;
    
    public bool GetCurrentWeapon(int distanceCategory)
    {
        _currentWeapon = _inventory.GetWeapon(distanceCategory);
        
        if (_currentWeapon != null)
        {
            Distance = _currentWeapon.Distance;
            return true;
        }
        
        return false;
    }
    
    public void AddNewWeaponToInventory(IWeapon? weapon)
    {
        _inventory.AddNewWeapon(weapon);
    }
    
 
    public void GetExperience(double exp)
    {
        _experience += exp;
        
        LevelUp();
    }
    
    public void LevelUp()
    {
        if (_experience >= 30.0)
        {
            _level += 1;
            _damagePoints += 5;
            _experience = 0;
        }
    }
    
    
    public double HealthPoints
    {
        get => _healthPoints;
        set => _healthPoints = value;
    }
    
    

    public Guid Id { get; } = Guid.NewGuid();
    
    public string Username { get; private set; } 
    
    public void GetDamage(double damage)
    {
        HealthPoints -= damage;
        if (HealthPoints <= 0)
            HealthPoints = 0;
    }
    
    public bool IsDead()
    {
        return HealthPoints <= 0;
    }


}