using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lld_console_app.DecoratorPattern
{
    public class ExtraCheese : ToppingsDecorator
    {

        BasePizza basePizza;
        public ExtraCheese(BasePizza basePizza){
            this.basePizza = basePizza;
        }
        
        public override int Cost()
        {
            return this.basePizza.Cost() + 10;
        }
    }
}
