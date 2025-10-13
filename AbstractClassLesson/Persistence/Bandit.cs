using AbstractClassLesson.Game;


namespace AbstractClassLesson.Persistence;

public class Bandit : AgressiveNpc
{

    public Bandit(string name)
    {
        Name = name;
    }
    
    //(public double DoMeleDamage(double x, double y)
    //{
    //    var distance = Math.Sqrt((Math.Pow(x, 2) - Math.Pow(Position.x, 2) + (Math.Pow(y, 2) - Math.Pow
    //        (Position.y, 2))));
    //
    //    if (distance > 2)
    //        return 0;
    //
    //    return DoDamage(2);
    //}    
    


    //public double DoRangeDamage(double x, double y)
    //{
    //    var distance = Math.Sqrt((Math.Pow(x, 2) - Math.Pow(Position.x, 2) + (Math.Pow(y, 2) - Math.Pow
    //        (Position.y, 2))));
    //
    //    if (distance <= 2 & distance <= 20)
    //        return 0;
    //
    //    return DoDamage(1);
    //}

    public override double DamagePoints { get; set; } = 30;
}