using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public class BuyOneGetOneRule:IPricingRule
    {       
        private readonly int _unitPrice;
        public string Sku { get; }
        public BuyOneGetOneRule(string sku, int unitPrice)
        {
            Sku = sku;
            _unitPrice = unitPrice;
        }

        public int Calculate(IEnumerable<string> items)
        {
            var count = items.Count(i => i == Sku);
            return ((count / 2) + (count % 2)) * _unitPrice;
        }
    }
}
