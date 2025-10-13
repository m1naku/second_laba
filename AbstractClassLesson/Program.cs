using AbstractClassLesson.Game;
using AbstractClassLesson.Game.Logs;
using AbstractClassLesson.Persistence;

var logger = new Logger(Console.WriteLine);

var npcList = new List<AgressiveNpc>();

var puck = EnemyFactory.CreateNpc("Puck", EnemyType.Bandit);
var luck = EnemyFactory.CreateNpc("Luck", EnemyType.Wolf);
var pock = EnemyFactory.CreateNpc("Pock", EnemyType.ForestBandit);
var meck = EnemyFactory.CreateNpc("Meck", EnemyType.Wolf);

npcList.Add(puck);
npcList.Add(luck);
npcList.Add(pock);
npcList.Add(meck);

var player = new Player("m1naku")
{
    HealthPoints = 150,
};


var GameShell = new Game(logger, player);

foreach (var npc in npcList)
{
    GameShell.Subscribe(npc);
}

GameShell.RunGame();