using AbstractClassLesson.Game.Logs;
using AbstractClassLesson.Persistence;

namespace AbstractClassLesson.Game;


public class Game
{
    public Game(Logger logger, Player player)
    {
       _logger = logger;
       _player = player;
    }
    
    private readonly List<AgressiveNpc> _entityList = [];

    private readonly Player _player;

    private readonly Logger _logger;

    public void Subscribe(AgressiveNpc npc)
    {
        if (!_entityList.Contains(npc))
            _entityList.Add(npc);
        else
        {
            throw new Exception("This npc already exists");
        }
    }

    public void Unsubscribe(AgressiveNpc npc)
    {
        if (_entityList.Contains(npc))
            _entityList.Remove(npc);
        else
        {
            throw new Exception("This npc does not exists");
        }
    }

    private void ClearEntityList()
    {
        _entityList.Clear();
    }

    public void RunGame()
    {
        _logger.Log($"Starting game: {_player.Username} vs {_entityList.Count} enemies!");

        for (int i = 0; i < _entityList.Count; i++)
        {
            _logger.Log($"The fight №{i+1}: vs {_entityList[i].Name}");

            while (_player.HealthPoints > 0 && _entityList[i].HealthPoints > 0)
            {
                Attack(_player, _entityList[i]);
            }
            
        }

        if (!_player.IsDead())
        {
            _logger.Log("Game over! The player won!");
        }
        else
        {
            _logger.Log("Game over! Player is dead!");
        }
    }

    private void Attack(Player player, AgressiveNpc npc)
    {
        _logger.AttackLogByPlayer(player, npc);
        npc.GetDamage(player.DamagePoints);
        _logger.AfterAttackLogByNpc(npc);
        if (npc.IsDead())
        {
            _logger.NpcIsDead(npc);
            player.GetExperience(npc.ExpGranted);
            return;
        }
            
        
        _logger.AttackLogByNpc(player, npc);
        player.GetDamage(npc.DamagePoints);
        _logger.AfterAttackLogByPlayer(player);
    }
}

public class Player(string username)
{
    private double _damagePoints = 50;
    
    private double _healthPoints = 100.0;

    private int _level = 1;

    private double _experience = 0;
    
    public int Level => _level;

    public void GetExperience(double exp)
    {
        _experience += exp;
        
        LevelUp();
    }
    
    public void LevelUp()
    {
        for (var i = 0; i < _experience / 30.0; i++)
        {
            _level += 1;
            _damagePoints += 5;
            _experience = 0;
        }
    }
    
    public double DamagePoints => _damagePoints;
    
    public double HealthPoints
    {
        get => _healthPoints;
        set => _healthPoints = value;
    }
    
    

    public Guid Id { get; } = Guid.NewGuid();
    
    public string Username { get; private set; } = username;
    
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