using System.Runtime.InteropServices;

namespace AbstractClassLesson.Game;
using AbstractClassLesson.Game;
using AbstractClassLesson.Persistence;

public static class EnemyFactory
{
    public static AgressiveNpc CreateNpc([Optional] string npcName, EnemyType enemyType)
    {
        return enemyType switch
        {
            EnemyType.Wolf => new Wolf()
            {
                Position =  (1, 1),
            },
            EnemyType.Bandit => new Bandit(npcName)
            {
                Level = 1,
                HealthPoints = 150,
                Position = ( 15, 15 ),
            },
            EnemyType.ForestBandit => new ForestBandit(npcName)
            {
                Level = 1,
                HealthPoints = 100,
                Position = ( 30, 30),
            },
            _ => throw new NotImplementedException("Unknown enemy type!")
        };
    }
}

public enum EnemyType
{
    Wolf,
    Bandit,
    ForestBandit,
}