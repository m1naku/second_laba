namespace AbstractClassLesson.Game.Logs;
using AbstractClassLesson.Game.Logs;

using AbstractClassLesson.Persistence;


public class Logger
{
    public Logger(Action<string> logAction)
    {
        _logAction = logAction;
    }
    private readonly Action<string> _logAction;

    public void Log(string logMessage)
    {
        _logAction(logMessage);
    }

    public void AttackLogByPlayer(Player player, AgressiveNpc npc)
    {
        _logAction($"{player.Username} (Level: {player.Level} )attacks {npc.Name} ({npc.HealthPoints:F1} hp) with {player.DamagePoints} dmg.");
    }
    
    public void AttackLogByNpc(Player player, AgressiveNpc npc)
    {
        _logAction($"{npc.Name} attacks {player.Username} ({player.HealthPoints:F1} hp) with {npc.DamagePoints} dmg.");
    }

    public void AfterAttackLogByPlayer(Player player)
    {
        _logAction($"{player.Username} hp's after the attack: {player.HealthPoints:F1}");
    }
    
    public void AfterAttackLogByNpc(AgressiveNpc npc)
    {
        _logAction($"{npc.Name} hp's after the attack: {npc.HealthPoints:F1}");
    }

    public void NpcIsDead(AgressiveNpc npc)
    {
        _logAction($"{npc.Name} is dead");
    }
}