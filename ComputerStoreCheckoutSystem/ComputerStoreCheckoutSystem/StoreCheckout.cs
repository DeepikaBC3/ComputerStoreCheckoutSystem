namespace CheckoutSystem
{
    public class PricingRules
    {
        public string sku { get; set; }
        public string? name { get; set; }
        public double price { get; set; }
        public int offerQuantity { get; set; }
        public string? offerDeal { get; set; }
    }

    public class StoreCheckout : ICheckout
    {
        List<PricingRules> pricingRulesList = new List<PricingRules>();
        Dictionary<string, int> checkoutProductsList = new Dictionary<string, int>();

        public StoreCheckout(List<PricingRules> pricingRulesList)
        {
            this.pricingRulesList = pricingRulesList;
        }


        public void scan(string sku)
        {
            try
            {
                if (pricingRulesList.Any(prod => prod.sku == sku))
                {
                    if (checkoutProductsList.ContainsKey(sku))
                    {
                        checkoutProductsList[sku]= checkoutProductsList[sku] + 1;
                    }
                    else
                    {
                        checkoutProductsList.Add(sku, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void total()
        {
            try
            {
                double total = 0;

                if (checkoutProductsList.ContainsKey("vga"))
                {
                    total = total + pricingRulesList.Find(x => x.sku == "vga").price;
                }

                foreach (var rules in pricingRulesList)
                {
                    if (rules.sku != null && checkoutProductsList.ContainsKey(rules.sku))
                    {
                        if (rules.sku == "atv" && checkoutProductsList.ContainsKey(rules.sku))
                        {
                            if (checkoutProductsList[rules.sku] % rules.offerQuantity == 0)
                            {
                                total = total + (checkoutProductsList[rules.sku] / rules.offerQuantity) *
                                2 * rules.price;
                            }
                            else
                            {
                                total = total + (checkoutProductsList[rules.sku] * rules.price);
                            }
                        }

                        if (rules.sku == "ipd" && checkoutProductsList.ContainsKey("ipd"))
                        {
                            if(checkoutProductsList[rules.sku] > rules.offerQuantity)
                            {
                                total = total + (checkoutProductsList[rules.sku] * 499.99);
                            }
                            else
                            {
                                total = total + (checkoutProductsList[rules.sku] * rules.price);
                            }
                            
                        }

                        if (rules.sku == "mbp" && checkoutProductsList.ContainsKey("mbp"))
                        {
                            if (checkoutProductsList[rules.sku] > 0)
                            {
                                total = total + (checkoutProductsList[rules.sku] * rules.price);
                                if (checkoutProductsList.ContainsKey("vga"))
                                {
                                    checkoutProductsList["vga"] = checkoutProductsList["vga"] + checkoutProductsList[rules.sku];
                                }
                                else
                                {
                                    checkoutProductsList.Add("vga", checkoutProductsList[rules.sku]);
                                }
                            }
                            else
                            {
                                total = total + (checkoutProductsList[rules.sku] * rules.price);
                            }
                        }
                    }
                }

                foreach (var product in checkoutProductsList)
                {
                    Console.WriteLine(product.Key + " ==> " + product.Value);
                }
                Console.WriteLine("Amount to be paid => " + total);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
