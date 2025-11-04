using AbstractClassLesson.Game.Logs;
using AbstractClassLesson.Persistence;
using AbstractClassLesson.Persistence.Items;
using AbstractClassLesson.Persistence.Weapon;


namespace AbstractClassLesson.Game;


public class Game
{
    public Game(ILogger logger,Player player)
    {
       _logger = logger;
       _player = player;
    }
    
    private readonly List<AgressiveNpc> _entityList = [];

    private readonly Player _player;

    private readonly ILogger _logger;
    
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
         
            int distance = AgressiveNpc.AggressionArea(_entityList[i], _player.Position.x,_player.Position.y);
            _logger.Log($"The distance is {distance}");
            

            while (_player.HealthPoints > 0 && _entityList[i].HealthPoints > 0)
            {
                Attack(_player, _entityList[i], distance);
            }

            _player.Kills++;
        }

        if (!_player.IsDead())
        {
            _logger.Log("Game over! The player won!");
        }
        else
        {
            _logger.Log("Game over! Player is dead!");
        }
        
        _logger.Log($"Total damage by Player is {_player.DamageInfo}");
        _logger.Log($"Total kills is {_player.Kills}");
    }

    private void Attack(Player player, AgressiveNpc npc, int distance)
    {
        if (!player.GetCurrentWeapon(distance))
        {
            _logger.Log($"{player.Username} не имеет подходящего оружия для дистанции {distance}!");
            return;
        }
        
        _logger.Log($"{player.Username} (Level: {player.Level}) attacks {npc.Name} ({npc.HealthPoints:F1} hp) with {player.TotalDamage} dmg.Weapon - {player.Weapon?.Name}.");
        npc.GetDamage(player.TotalDamage);
        player.DamageInfo += player.TotalDamage;
        _logger.Log($"{npc.Name} hp's after the attack: {npc.HealthPoints:F1}");
        if (npc.IsDead())
        {
            _logger.Log($"{npc.Name} is dead");
            player.GetExperience(npc.ExpGranted);
            return;
        }
        
        player.GetDamage(npc.DamagePoints);
        _logger.Log($"{player.Username} hp's after the attack: {player.HealthPoints:F1}");
    }
}

