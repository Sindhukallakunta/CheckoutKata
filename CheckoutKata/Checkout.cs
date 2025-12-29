using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout:ICheckout
    {
        public Checkout(PricingRules pricingRules)
        {
        }

        public void Scan(string item)
        {
        }

        public int GetTotalPrice()
        {
            return 0;
        }
    }
}
