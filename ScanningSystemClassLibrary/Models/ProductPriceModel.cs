using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanningSystemClassLibrary.Models
{
    public class ProductPriceModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool HasBulkPrice { get; set; }
        public int BulkQuantity { get; set; }
        public decimal BulkPrice { get; set; }
    }
}
