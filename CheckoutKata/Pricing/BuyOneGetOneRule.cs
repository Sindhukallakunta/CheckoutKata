using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public class BuyOneGetOneRule:IPricingRule
    {
        private readonly string _sku;
        private readonly int _unitPrice;

        public BuyOneGetOneRule(string sku, int unitPrice)
        {
            _sku = sku;
            _unitPrice = unitPrice;
        }

        public int Calculate(IEnumerable<string> items)
        {
            var count = items.Count(i => i == _sku);
            return ((count / 2) + (count % 2)) * _unitPrice;
        }
    }
}
