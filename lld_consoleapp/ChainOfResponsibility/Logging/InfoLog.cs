
namespace lld_console_app.ChainOfResponsibility.Logging
{
    public class InfoLog : LogHandler
    {


        public InfoLog(LogHandler logHandler) : base(logHandler)
        {
        }   
        public override void Log(String logType)
        {
            if(logType.Equals("INFO"))
            {
                Console.WriteLine("Info log");
            }
            else
            {
                this.nextHandler.Log(logType);
            }
        }
    }
}

