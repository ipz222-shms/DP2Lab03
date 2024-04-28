namespace AdapterLibrary;

public class Logger
{
    internal string GenerateLogMessage(LogType type, string message)
    {
        switch (type)
        {
            case LogType.Error:
                return $"[{DateTime.Now:g}] ERROR: {message}";
            case LogType.Warn:
                return $"[{DateTime.Now:g}] WARNING: {message}";
            case LogType.Log:
            default:
                return $"[{DateTime.Now:g}] LOG: {message}";
        }
    }
    
    public virtual void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(GenerateLogMessage(LogType.Log, message));
        Console.ResetColor();
    }

    public virtual void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(GenerateLogMessage(LogType.Error, message));
        Console.ResetColor();
    }
    
    public virtual void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(GenerateLogMessage(LogType.Warn, message));
        Console.ResetColor();
    }
}
