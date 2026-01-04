using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public class MultiBuyRule:IPricingRule
    {
        public string Sku { get; }
        private readonly int _quantity;
        private readonly int _offerPrice;
        private readonly int _unitPrice;

        public MultiBuyRule(string sku, int quantity, int offerPrice, int unitPrice)
        {
            Sku = sku;
            _quantity = quantity;
            _offerPrice = offerPrice;
            _unitPrice = unitPrice;
        }

        public int Calculate(IEnumerable<string> items)
        {
            var count = items.Count(i => i == Sku);
            return (count / _quantity) * _offerPrice
                 + (count % _quantity) * _unitPrice;
        }
    }
}
