using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public sealed class PricingRules
    {
        public IReadOnlyDictionary<string, int> UnitPrices { get; }
        public IReadOnlyDictionary<string, MultiBuyOffer> Offers { get; }

        public PricingRules(IReadOnlyDictionary<string, int> unitPrices) : this(unitPrices, new Dictionary<string, MultiBuyOffer>())
        {
        }

        public PricingRules(IReadOnlyDictionary<string, int> unitPrices, IReadOnlyDictionary<string, MultiBuyOffer> offers)
        {
            UnitPrices = unitPrices;
            Offers = offers;
        }
        public static PricingRules Empty()
        {
            return new PricingRules(new Dictionary<string, int>());
        }

    }
}
