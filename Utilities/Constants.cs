using System;
using System.Collections.Generic;
using WebMailing.Models.ViewModels;

namespace Utilities
{
    public static class Constants
    {
        public static List<AscendingOrder> AscendingList = new List<AscendingOrder> {
                new AscendingOrder { Name = "Ascending", IsAscending = true } ,
                new AscendingOrder { Name = "Descending", IsAscending = false }
            };
    }
}
