using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public class MultiBuyRule:IPricingRule
    {
        private readonly string _sku;
        private readonly int _quantity;
        private readonly int _offerPrice;
        private readonly int _unitPrice;

        public MultiBuyRule(string sku, int quantity, int offerPrice, int unitPrice)
        {
            _sku = sku;
            _quantity = quantity;
            _offerPrice = offerPrice;
            _unitPrice = unitPrice;
        }

        public int Calculate(IEnumerable<string> items)
        {
            var count = items.Count(i => i == _sku);
            return (count / _quantity) * _offerPrice
                 + (count % _quantity) * _unitPrice;
        }
    }
}
