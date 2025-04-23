using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lld_console_app.DecoratorPattern
{
    public class Mushroom : ToppingsDecorator
    {
        public BasePizza basePizza;

        public Mushroom(BasePizza basePizza) 
        {
            this.basePizza = basePizza;
        }

        public override int Cost()
        {
            return basePizza.Cost() + 30;
        }
    }
}
