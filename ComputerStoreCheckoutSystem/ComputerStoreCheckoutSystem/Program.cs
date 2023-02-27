namespace CheckoutSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                List<PricingRules> pricingRulesList = new List<PricingRules>();
                PricingRules pricingRulesObj = new PricingRules();

                /*
                | SKU     | Name        | Price    |
                | --------|:-----------:| --------:|
                | ipd     | Super iPad  | $549.99  |
                | mbp     | MacBook Pro | $1399.99 |
                | atv     | Apple TV    | $109.50  |
                | vga     | VGA adapter | $30.00   |*/

                pricingRulesObj.sku = "atv";
                pricingRulesObj.name = "Apple TV";
                pricingRulesObj.price = 109.50;
                pricingRulesObj.offerQuantity = 3;
                pricingRulesObj.offerDeal = "Buy 3 Apple TVs, pay the price of 2 only";
                pricingRulesList.Add(pricingRulesObj);

                pricingRulesObj = new PricingRules();
                pricingRulesObj.sku = "ipd";
                pricingRulesObj.name = "Super iPad";
                pricingRulesObj.price = 549.99;
                pricingRulesObj.offerQuantity = 4;
                pricingRulesObj.offerDeal = "Buy 4 iPad, price will drop to $499.99 each";
                pricingRulesList.Add(pricingRulesObj);

                pricingRulesObj = new PricingRules();
                pricingRulesObj.sku = "mbp";
                pricingRulesObj.name = "MacBook Pro";
                pricingRulesObj.price = 1399.99;
                pricingRulesObj.offerQuantity = 1;
                pricingRulesObj.offerDeal = "Buy 1 MacBook Pro, get free VGA adapter free";
                pricingRulesList.Add(pricingRulesObj);

                pricingRulesObj = new PricingRules();
                pricingRulesObj.sku = "vga";
                pricingRulesObj.name = "VGA adapter";
                pricingRulesObj.price = 30.00;
                pricingRulesObj.offerQuantity = 0;
                pricingRulesObj.offerDeal = "";
                pricingRulesList.Add(pricingRulesObj);

                StoreCheckout storeCheckoutObj = new StoreCheckout(pricingRulesList);


                storeCheckoutObj.scan("ipd");
                storeCheckoutObj.scan("ipd");
                storeCheckoutObj.scan("ipd");
                storeCheckoutObj.scan("ipd");
                storeCheckoutObj.scan("ipd");

                storeCheckoutObj.scan("atv");
                storeCheckoutObj.scan("atv");
                storeCheckoutObj.scan("atv");

                storeCheckoutObj.scan("mbp");
                storeCheckoutObj.scan("mbp");

                storeCheckoutObj.total();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}