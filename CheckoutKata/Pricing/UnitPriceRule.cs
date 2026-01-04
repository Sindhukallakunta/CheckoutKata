using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public class UnitPriceRule:IPricingRule
    {
        public string Sku { get; }
        private readonly int _unitPrice;

        public UnitPriceRule(string sku, int unitPrice)
        {
            Sku = sku;
            _unitPrice = unitPrice;
        }

        public int Calculate(IEnumerable<string> items)
        {
            return items.Count(i => i == Sku) * _unitPrice;
        }
    }
}
