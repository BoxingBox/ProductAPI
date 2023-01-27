namespace ProductAPI.Logging
{
    public class LoggingContext : ILoggingContext
    {
        private readonly ILogger<LoggingContext> logger;

        public LoggingContext(ILogger<LoggingContext> logger) =>
            this.logger = logger;
        
        public void LogCritical(Exception exception) =>
            this.logger.LogCritical( exception, exception.Message);

        public void LogDebug(string message) =>
            this.logger.LogDebug(message);

        public void LogError(Exception exception) =>
            this.logger.LogError(exception, exception.Message);

        public void LogInformation(string message) =>
            this.logger.LogInformation(message);

        public void LogTrace(string message) =>
            this.logger.LogTrace(message);

        public void LogWarning(string message) =>
            this.logger.LogWarning(message);
    }
}
