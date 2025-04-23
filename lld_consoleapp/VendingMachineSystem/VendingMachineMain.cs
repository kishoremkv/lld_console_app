// here we are going to use State level design pattern

using System.Runtime.InteropServices.Marshalling;

namespace lld_console_app.VendingMachineSystem
{
    // Define states and what operations to do


    public abstract class IState // create interface or abstract class
    {
        public abstract void PressInsertCoinButton();
        public virtual void GoToIdleState(){}
        public abstract void CollectMoney();
        public abstract void PressProductSelectionButton();
        public abstract void ProductDispense();
        public abstract void CancelOrRefund();
    }

    public class Test : IState
    {
        public override void PressInsertCoinButton()
        {
            throw new NotImplementedException();
        }

        public override void GoToIdleState()
        {

        }

        public override void CollectMoney()
        {
            throw new NotImplementedException();
        }

        public override void PressProductSelectionButton()
        {
            throw new NotImplementedException();
        }

        public override void ProductDispense()
        {
            throw new NotImplementedException();
        }

        public override void CancelOrRefund()
        {
            throw new NotImplementedException();
        }
    }

    public enum CurrentState
    {
        IDLE,
        HAS_MONEY,
        SELECT_PRODUCT,
        DISPENSE_MONEY
    }
}