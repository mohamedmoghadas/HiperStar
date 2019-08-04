using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    public class PricePart
    {
       
            public static string SplitPrice(string price)
            {
                try
                {
                    if (price != null)
                    {
                        String res = "";
                        for (int i = price.Length - 1; i >= 0; i--)
                        {
                            res += price[i];

                            if (price.Length % 3 == 0 && i % 3 == 0)
                            {
                                res += "/";
                            }
                            else if (price.Length % 3 == 1 && i % 3 == 1)
                            {
                                res += "/";
                            }
                            else if (price.Length % 3 == 2 && i % 3 == 2)
                            {
                                res += "/";
                            }
                        }

                        if (price.Length % 3 == 0)
                        {
                            int index = res.LastIndexOf("/");
                            res = res.Remove(index, 1);
                        }
                        char[] arr = res.ToCharArray();
                        Array.Reverse(arr);
                        return new string(arr);
                    }
                    else
                    {
                        return "";
                    }
                }
                catch (Exception)
                {
                    return price;
                }
            }
        
    }
}