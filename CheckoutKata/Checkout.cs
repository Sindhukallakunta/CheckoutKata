using CheckoutKata.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout:ICheckout
    {
        
        private readonly List<string> _items = new();
        private readonly IEnumerable<IPricingRule> _pricingRules;
        private readonly HashSet<string> _knownSkus;
        public Checkout(IEnumerable<IPricingRule> pricingRules)
        {
            _pricingRules = pricingRules ?? throw new ArgumentNullException(nameof(pricingRules));
            _knownSkus = new HashSet<string> { "A", "B", "C", "D" };
        }

        public void Scan(string item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (!_knownSkus.Contains(item))
                throw new ArgumentException($"Unknown SKU: {item}");

            _items.Add(item);
        }

        public int GetTotalPrice()
        {
            return _pricingRules.Sum(rule=>rule.Calculate(_items));
        }
    }
}
