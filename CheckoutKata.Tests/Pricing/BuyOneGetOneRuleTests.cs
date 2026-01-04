using CheckoutKata.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests.Pricing
{
    public class BuyOneGetOneRuleTests
    {
        [Test]
        public void Every_Second_Item_Is_Free()
        {
            var rule = new BuyOneGetOneRule("A", 50);
            var items = new[] { "A", "A", "A" };

            Assert.That(rule.Calculate(items), Is.EqualTo(100));
        }
    }
}
