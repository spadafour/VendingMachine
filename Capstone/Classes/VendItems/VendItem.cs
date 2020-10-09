using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Capstone.Classes.VendItems
{
    public abstract class VendItem
    {
        public string SlotNumber { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; protected set; }
        public string Message { get; protected set; }
    }
}
