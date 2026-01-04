using CheckoutKata.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests.Pricing
{
    public class PercentageDiscountRuleTests
    {
        [Test]
        public void Applies_Percentage_Discount()
        {
            var rule = new PercentageDiscountRule("A", 100, 0.10m);
            var items = new[] { "A", "A" };

            Assert.That(rule.Calculate(items), Is.EqualTo(180));
        }
    }
}
