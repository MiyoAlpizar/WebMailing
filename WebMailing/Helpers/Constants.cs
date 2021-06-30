using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMailing.Models;

namespace WebMailing.Helpers
{
    public static class Constants
    {
        public static List<AscendingOrder> AscendingList = new() {
                new AscendingOrder { Name = "Ascending", IsAscending = true } ,
                new AscendingOrder { Name = "Descending", IsAscending = false }
            };
    }
}
