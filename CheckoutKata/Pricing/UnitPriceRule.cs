using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public class UnitPriceRule:IPricingRule
    {
        private readonly string _sku;
        private readonly int _unitPrice;

        public UnitPriceRule(string sku, int unitPrice)
        {
            _sku = sku;
            _unitPrice = unitPrice;
        }

        public int Calculate(IEnumerable<string> items)
        {
            return items.Count(i => i == _sku) * _unitPrice;
        }
    }
}
