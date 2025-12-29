using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout:ICheckout
    {
        private readonly PricingRules _rules;
        private readonly List<string> _items = new();
        public Checkout(PricingRules pricingRules)
        {
            _rules = pricingRules;
        }

        public void Scan(string item)
        {
            _items.Add(item);
        }

        public int GetTotalPrice()
        {
            return _items.Sum(i => _rules.UnitPrices[i]);
        }
    }
}
