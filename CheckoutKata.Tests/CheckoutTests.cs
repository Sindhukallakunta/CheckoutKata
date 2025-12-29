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
    }
}