using Microsoft.Extensions.Logging;

namespace Warships.common.Utility;

public class WarShipLogger : ILogger
{
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
       Console.WriteLine($"{logLevel}");
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }
}