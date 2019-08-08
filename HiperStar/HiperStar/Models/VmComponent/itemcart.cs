using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiperStar.Models.VmComponent
{
    public class itemcart
    {

        public ListProp[] ListProps { get; set; }
    }

    public class ListProp
    {
        public long Id { get; set; }
        public long Value { get; set; }
    }
}