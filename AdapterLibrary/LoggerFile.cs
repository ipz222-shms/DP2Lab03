namespace AdapterLibrary;

public class LoggerFile(Logger logger, string logFileName = "log.txt") : Logger
{
    private readonly Logger _adaptee = logger;
    private readonly FileWriter _writer = new();
    public readonly string FileName = logFileName;

    public override void Log(string message)
        => _writer.WriteLine(FileName, _adaptee.GenerateLogMessage(LogType.Log, message));

    public override void Error(string message)
        => _writer.WriteLine(FileName, _adaptee.GenerateLogMessage(LogType.Error, message));

    public override void Warn(string message)
        => _writer.WriteLine(FileName, _adaptee.GenerateLogMessage(LogType.Warn, message));
}
