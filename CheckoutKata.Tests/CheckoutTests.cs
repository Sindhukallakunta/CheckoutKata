namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        [Test]
        public void Empty_Checkout_Returns_Zero()
        {
            var checkout = new Checkout(PricingRules.Empty());

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(0));
        }

        [Test]
        public void Single_Item_Returns_Unit_Price()
        {
            var rules = new PricingRules(
                new Dictionary<string, int> { ["A"] = 50 }
            );

            var checkout = new Checkout(rules);
            checkout.Scan("A");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(50));
        }

        [Test]
        public void Order_Does_Not_Matter()
        {
            var rules = new PricingRules(
                new Dictionary<string, int>
                {
                    ["A"] = 50,
                    ["B"] = 30
                }
            );

            var checkout = new Checkout(rules);

            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(110));
        }

    }
}