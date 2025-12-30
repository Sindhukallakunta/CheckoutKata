using CheckoutKata.Pricing;

namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        [Test]
        public void Empty_Checkout_Returns_Zero()
        {
            var pricingRules = new IPricingRule[]
        {
            new UnitPriceRule("A", 50),
            new UnitPriceRule("B", 30)
        };

            var checkout = new Checkout(pricingRules);


            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(0));
        }

        [Test]
        public void Single_Item_Returns_Unit_Price()
        {
            var pricingRules = new IPricingRule[]
            {
              new UnitPriceRule("A", 50)
            };

            var checkout = new Checkout(pricingRules);
            checkout.Scan("A");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(50));
        }

        [Test]
        public void Order_Does_Not_Matter()
        {
            var pricingRules = new IPricingRule[]                
                {
                    new UnitPriceRule("A", 50),
                    new UnitPriceRule("B", 30)
                };
            

            var checkout = new Checkout(pricingRules);

            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(110));
        }

        [Test]
        public void Three_As_Cost_130()
        {
            var pricingRules = new IPricingRule[]
            {
               new MultiBuyRule("A", 3, 130, 50)
            };

            var checkout = new Checkout(pricingRules);

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(130));
        }


    }
}