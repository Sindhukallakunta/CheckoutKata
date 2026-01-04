using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public class PercentageDiscountRule:IPricingRule
    {
        public string Sku { get; }
        private readonly int _unitPrice;
        private readonly decimal _discount;

        public PercentageDiscountRule(string sku, int unitPrice, decimal discount)
        {
            Sku = sku;
            _unitPrice = unitPrice;
            _discount = discount;
        }

        public int Calculate(IEnumerable<string> items)
        {
            var count = items.Count(i => i == Sku);
            var total = count * _unitPrice;
            return (int)(total * (1 - _discount));
        }
    }
}
