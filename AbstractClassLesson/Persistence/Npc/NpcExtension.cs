namespace AbstractClassLesson.Persistence;

public static class NpcExtension
{
    public static double GetDistance(this Npc npc, double playerX, double playerY)
    {
        return Math.Sqrt((Math.Pow(npc.Position.x, 2) - Math.Pow(playerX, 2)) 
                         + (Math.Pow(npc.Position.y, 2) + Math.Pow(playerY, 2)));
    }
}