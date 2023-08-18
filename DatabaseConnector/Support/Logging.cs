using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using Serilog.Sinks.SystemConsole.Themes;
using System.Collections.Concurrent;

namespace DatabaseConnector.Support;

public static class Logging
{
    public static void SetupLogger(
        LogEventLevel logEventLevel = LogEventLevel.Debug,
        string logTemplate = "{Timestamp:HH:mm:ss.ff} | {Level:u3} | {Message}{NewLine}{Exception}")
    {



        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.ControlledBy(LoggingLevelSwitch) // Default's to Information 
            .WriteTo.Console(outputTemplate: logTemplate, theme: AnsiConsoleTheme.Code)
            .WriteTo.Debug(outputTemplate: logTemplate)
            .WriteTo.Sink(
                InMemorySink,
                logEventLevel,
                LoggingLevelSwitch).CreateLogger();

        LoggingLevelSwitch.MinimumLevel = logEventLevel;

        Log.Information(new string('█', 100));
        Log.Debug($"Logger is ready.");
    }


    #region Public Static Properties
    public static InMemorySink InMemorySink { get; private set; } = new InMemorySink();
    public static LoggingLevelSwitch LoggingLevelSwitch { get; } = new LoggingLevelSwitch();
    #endregion

    #region Private Properties
    #endregion

}


public class InMemorySink : ILogEventSink
{
    readonly ITextFormatter _textFormatter = new MessageTemplateTextFormatter("{Timestamp:HH:mm:ss.ff} | {Level:u3} | {Message}{NewLine}{Exception}");

    public ConcurrentQueue<string> Events { get; } = new ConcurrentQueue<string>();
    public event EventHandler<string> Logged;

    public void Emit(LogEvent logEvent)
    {
        if (logEvent != null && Logged != null)
        {
            var renderSpace = new StringWriter();
            _textFormatter.Format(logEvent, renderSpace);
            Events.Enqueue(renderSpace.ToString());

            Logged.Invoke(this, renderSpace.ToString());
        }
    }
}
