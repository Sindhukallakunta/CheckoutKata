using CheckoutKata.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests.Pricing
{
    public class MultiBuyRuleTests
    {
        [Test]
        public void Applies_Offer_When_Threshold_Met()
        {
            var rule = new MultiBuyRule("A", 3, 130, 50);
            var items = new[] { "A", "A", "A" };

            Assert.That(rule.Calculate(items), Is.EqualTo(130));
        }
    }
}
