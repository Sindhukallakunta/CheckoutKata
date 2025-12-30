using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public class CheckoutPriceCalculator
    {
        public int Calculate(IEnumerable<string> items, PricingRules rules)
        {
            var total = 0;

            foreach (var group in items.GroupBy(i => i))
            {
                var sku = group.Key;
                var count = group.Count();
                var unitPrice = rules.UnitPrices[sku];

                if (rules.Offers.TryGetValue(sku, out var offer))
                {
                    var bundles = count / offer.Quantity;
                    var remainder = count % offer.Quantity;

                    total += bundles * offer.Price;
                    total += remainder * unitPrice;
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
