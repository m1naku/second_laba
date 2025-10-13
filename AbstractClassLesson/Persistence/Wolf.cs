using AbstractClassLesson.Game;


namespace AbstractClassLesson.Persistence;

public class Wolf : AgressiveNpc
{
    

    public Wolf()
    {
        Name = "Wolf";
    }
    
    //public double DoMeleDamage(double x, double y)
    //{   
    //    var distance = Math.Sqrt((Math.Pow(x, 2) - Math.Pow(Position.x, 2) + (Math.Pow(y, 2) - Math.Pow
    //        (Position.y, 2))));
    //
    //    if (distance > 2)
    //        return 0;
    //
    //    return DoDamage(2);
    //}

    public override double DamagePoints { get; set; } = 15;
}