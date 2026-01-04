using CheckoutKata.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests.Pricing
{
    public class UnitPriceRuleTests
    {
        [Test]
        public void Calculates_Total_Using_Unit_Price()
        {
            var rule = new UnitPriceRule("A", 50);
            var items = new[] { "A", "A" };

            var total = rule.Calculate(items);

            Assert.That(total, Is.EqualTo(100));
        }
    }
}
