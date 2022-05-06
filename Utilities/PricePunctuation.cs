using System;

namespace Ecomm.Utilities
{
    public class PricePunctuation
    {
        public static string PriceComma(string amount)
        {
            string newDiscountedPrice = "";
            int count = 0;
            for (int i = amount.Length - 1; i >= 0; i--)
            {
                if (count > 0 && count % 3 == 0)
                {
                    newDiscountedPrice += "," + amount[i];
                }
                else
                {
                    newDiscountedPrice += amount[i];
                }
                count++;

            }
            char[] arr = newDiscountedPrice.ToCharArray();
            Array.Reverse(arr);
            amount = "";
            foreach (char c in arr)
            {
                amount += c;
            }
            return "$" + amount;
        }
    }
}
