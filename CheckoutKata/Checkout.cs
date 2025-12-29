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
            var total = 0;

            foreach (var group in _items.GroupBy(i => i))
            {
                var sku = group.Key;
                var count = group.Count();
                var unitPrice = _rules.UnitPrices[sku];

                if (_rules.Offers.TryGetValue(sku, out var offer))
                {
                    total += (count / offer.Quantity) * offer.Price;
                    total += (count % offer.Quantity) * unitPrice;
                }
                else
                {
                    total += count * unitPrice;
                }
            }

            return total;
        }
    }
}
