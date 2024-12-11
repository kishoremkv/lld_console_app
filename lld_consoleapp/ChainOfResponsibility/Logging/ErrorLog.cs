
namespace lld_console_app.ChainOfResponsibility.Logging
{
    public class ErrorLog : LogHandler
    {

        public ErrorLog(LogHandler logHandler) : base(logHandler)
        {
        }   
        public override void Log(String logType)
        {
            if(logType.Equals("ERROR"))
            {
                Console.WriteLine("Error log");
            }
            else
            {
                this.nextHandler.Log(logType);
            }
        }
    }
}

