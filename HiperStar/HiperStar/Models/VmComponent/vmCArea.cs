using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiperStar.Models.VmComponent
{
    public class vmCArea
    {
        public Customer Customer { get; set; }
        public List<CustomerProduct> CustomerProducts { get; set; }
        public List<CustomerProjectTicket> CustomerProjectTickets { get; set; }
    }
}