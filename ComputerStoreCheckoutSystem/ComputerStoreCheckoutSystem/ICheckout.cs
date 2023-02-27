namespace CheckoutSystem
{
    internal interface ICheckout
    {
        public void scan(string sku);
        public void total();
    }
}
