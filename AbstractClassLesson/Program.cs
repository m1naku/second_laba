using AbstractClassLesson.Game;
using AbstractClassLesson.Game.Logs;
using AbstractClassLesson.Persistence;



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



var fileLogger = new FileLogger();
fileLogger.AddNewFilePath("C:/123/log.txt");

var consoleLogger = new ConsoleLogger(Console.WriteLine);

var logList = new List<ILogger>();
logList.Add(consoleLogger);
logList.Add(fileLogger);

var observerlogger = new LoggerObserver(logList);

var GameShell = new Game(observerlogger, player);

foreach (var npc in npcList)
{
    GameShell.Subscribe(npc);
}

GameShell.RunGame();