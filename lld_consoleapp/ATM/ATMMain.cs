// uses state design pattern + chain of responsibility principle


namespace lld_console_app.ATMMain
{
    public abstract class CashWithDrawl
    {

        private CashWithDrawl NextProcessor;
        public CashWithDrawl(CashWithDrawl nextProcessor)
        {
            this.NextProcessor = nextProcessor;
        }

        public virtual void WithDrawl()
        {
            if(NextProcessor != null)
            {
                this.NextProcessor.WithDrawl();
            }
        }


    }

    public class TwoKWithDrawl : CashWithDrawl
    {
        public TwoKWithDrawl(CashWithDrawl nextProcessor) : base(nextProcessor)
        {
            Console.WriteLine("2K method called");
        }

        public override void WithDrawl()
        {
            base.WithDrawl();
        }
    }

    public class FiveHundredWithDrawl : CashWithDrawl
    {
        public FiveHundredWithDrawl(CashWithDrawl nextProcessor) : base(nextProcessor)
        {
            Console.WriteLine("500 method called");
        }

        public override void WithDrawl()
        {
            base.WithDrawl();
        }
    }

    public class ATMMain
    {
        public static void Run()
        {
            CashWithDrawl cashWithDrawl = new TwoKWithDrawl(new FiveHundredWithDrawl(null));
            cashWithDrawl.WithDrawl();
        }
    }

}