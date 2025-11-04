using AbstractClassLesson.Game;

namespace AbstractClassLesson.Persistence;
using AbstractClassLesson.Game.Logs;

using AbstractClassLesson.Persistence;


public class ForestBandit : Bandit
{
    public new EnemyType Type => EnemyType.ForestBandit;
    public ForestBandit(string name) : base(name)
    {
        Level = 5;
        HealthPoints = 200.0;
    }

    public override double GetExp()
    {
        ExpGranted *= 2.0;
        return base.GetExp();
    }

}