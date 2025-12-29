using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public sealed class PricingRules
    {
        public IReadOnlyDictionary<string, int> UnitPrices { get; }

        public PricingRules(IReadOnlyDictionary<string, int> unitPrices)
        {
            UnitPrices = unitPrices;
        }
        public static PricingRules Empty()
        {
            return new PricingRules(new Dictionary<string, int>());
        }

    }
}
