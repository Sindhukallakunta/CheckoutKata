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
            if (pricingRules == null)
                throw new ArgumentNullException(nameof(pricingRules));

            var rules = pricingRules.ToList();

            if (!rules.Any())
                throw new ArgumentException("At least one pricing rule is required");
            
            _pricingRules = rules;
            _knownSkus = new HashSet<string> { "A", "B", "C", "D" };

            if (_pricingRules.Count() != _knownSkus.Count)
                throw new InvalidOperationException("Duplicate pricing rules detected");

        }

        public void Scan(string item)
        {          
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException("SKU cannot be empty", nameof(item));

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
