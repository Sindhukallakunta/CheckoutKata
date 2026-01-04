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

        [Test]
        public void Mixed_Basket_With_Offers_Applies_MultiBuy_Correctly()
        {
            var pricingRules = new IPricingRule[]
            {
               new MultiBuyRule("A", 3, 130, 50),
               new MultiBuyRule("B", 2, 45, 30)
            };

            var checkout = new Checkout(pricingRules);

            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(95));
        }
        [Test]
        public void Mixed_Basket_Without_Offer_On_B_Uses_Unit_Pricing()
        {
            var pricingRules = new IPricingRule[]
            {
              new MultiBuyRule("A", 3, 130, 50),
              new UnitPriceRule("B", 30)
            };

            var checkout = new Checkout(pricingRules);

            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(110));
        }

        [Test]
        public void ComplexScenario_MultipleOffersAndItems()
        {
            var pricingRules = new IPricingRule[]
           {
               new MultiBuyRule("A", 3, 130, 50),
               new MultiBuyRule("B",2, 45, 30),
               new UnitPriceRule("C", 20),
               new UnitPriceRule("D", 15),
              
           };
            var checkout = new Checkout(pricingRules);

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(260));
        }


        [Test]
        public void Scan_Unknown_SKU_Throws()
        {
            var rules = new IPricingRule[]
            {
               new UnitPriceRule("A", 50)
            };

            var checkout = new Checkout(rules);

            Assert.Throws<ArgumentException>(() => checkout.Scan("Z"));
        }

        [Test]
        public void Scan_Null_SKU_Throws()
        {
            var checkout = new Checkout(new[] { new UnitPriceRule("A", 50) });

            Assert.Throws<ArgumentNullException>(() => checkout.Scan(null));
        }

        [Test]
        public void Scan_Empty_SKU_Throws()
        {
            var checkout = new Checkout(new[] { new UnitPriceRule("A", 50) });

            Assert.Throws<ArgumentException>(() => checkout.Scan(""));
        }

    }
}