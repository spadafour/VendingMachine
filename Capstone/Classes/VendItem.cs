using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ItemNumber { get; set; }
        public string Type { get; set; }
        //Seems like OutputText will not be included in input file?
    }
}
