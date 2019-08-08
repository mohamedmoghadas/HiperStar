using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiperStar.Models.VmComponent
{
    public class vmPayment
    {
        public Customer Customerinfo { get; set; }

        public long? Amount { get; set; }

        public long sendcoust { get; set; }

        public List<CustomerProduct> CustomerProduct { get; set; }

    }



    public class vmPayments
    {


        public long Amount { get; set; }

        public string paymentmethod { get; set; }

        public long discountCod { get; set; }


    }
}