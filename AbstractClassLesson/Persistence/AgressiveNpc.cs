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
}