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
    }
}