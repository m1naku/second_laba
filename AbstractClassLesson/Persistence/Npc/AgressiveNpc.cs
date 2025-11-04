namespace AbstractClassLesson.Persistence;

public abstract class AgressiveNpc : Npc
{
    public abstract double DamagePoints { get; set; }

    public void GetDamage(double damage)
    {
        HealthPoints -= damage;
        if (HealthPoints <= 0)
            HealthPoints = 0;
    }
    
    public static int AggressionArea(Npc npc, double playerX, double playerY)
    {
        var distance = npc.GetDistance(playerX, playerY);

        return distance switch
        {
            > 40 => 2,
            > 10 and <=40 => 1,
            < 10 and >=0 => 0,
            < 0.0 => throw new ArgumentOutOfRangeException("Дистанция не может быть отрицательная!"),
            _ => throw new ArgumentOutOfRangeException("Невозможно вычислить дистанцию!")
        };
    }

}