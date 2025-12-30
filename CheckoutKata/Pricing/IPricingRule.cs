using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Pricing
{
    public interface IPricingRule
    {
        int Calculate(IEnumerable<string> items);
    }
}
