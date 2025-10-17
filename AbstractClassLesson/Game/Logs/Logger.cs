namespace AbstractClassLesson.Game.Logs;
using AbstractClassLesson.Game.Logs;

using AbstractClassLesson.Persistence;


// Выполнить функциональную декомпозицию при помощи интерфейсов
// Сделать логгер универсальным

public interface ILogger
{
    bool Log(string message);
}

public class FileLogger : ILogger
{
    private string _filePath;
    public bool Log(string message)
    {
        if (message != null && !string.IsNullOrEmpty(message))
        {
            if (File.Exists(_filePath))
            {
                File.AppendAllText(_filePath, message + Environment.NewLine);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool CheckExistance(string filePath)
    {
        return File.Exists(filePath);
    }
    public void AddNewFilePath(string filePath)
    {
        _filePath = filePath;
    }
    public bool GenerateFileByPath()
    {
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath);
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class ConsoleLogger : ILogger
{
    public ConsoleLogger(Action<string> logAction)
    {
        _logAction = logAction;
    }
    
    private readonly Action<string> _logAction;
    
    
    public bool Log(string logMessage)
    {
        _logAction(logMessage);
        return true;
    }
}

public class LoggerObserver : ILogger
{
    private readonly List<ILogger> _loggers = [];

    public LoggerObserver(List<ILogger> loggers)
    {
        _loggers = loggers;
    }

    public bool Log(string message)
    {
        foreach (var logger in _loggers)
        {
            logger.Log(message);
        }

        return true;
    }
}