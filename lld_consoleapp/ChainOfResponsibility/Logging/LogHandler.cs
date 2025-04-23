
namespace lld_console_app.ChainOfResponsibility.Logging
{
    public abstract class LogHandler
    {
        
        public LogHandler nextHandler = null;

        public LogHandler(LogHandler handler)
        {
            this.nextHandler = handler;
        }
        public abstract void Log(String logType);


    }
}

