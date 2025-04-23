
namespace lld_console_app.ChainOfResponsibility.Logging
{
    public class DebugLog : LogHandler
    {


        public DebugLog(LogHandler logHandler) : base(logHandler)
        {
        }   
        public override void Log(String logType)
        {
            if(logType.Equals("DEBUG"))
            {
                Console.WriteLine("Debug log");
            }
            else
            {
                this.nextHandler.Log(logType);
            }
        }
    }
}

