using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanningSystemClassLibrary.Constants
{
    public class ProductsConstants
    {
        public static readonly string[] products = { "A", "B", "C", "D" };

        public const string productA = "A";
        public const string productB = "B";
        public const string productC = "C";
        public const string productD = "D";

        public const decimal priceProductA = 1.25m;
        public const decimal priceProductB = 4.25m;
        public const decimal priceProductC = 1.00m;
        public const decimal priceProductD = 0.75m;

        public const bool hasBulkPriceA = true;
        public const bool hasBulkPriceB = false;
        public const bool hasBulkPriceC = true;
        public const bool hasBulkPriceD = false;

        public const int bulkItemProductA = 3;
        public const int bulkItemProductB = 0;
        public const int bulkItemProductC = 6;
        public const int bulkItemProductD = 0;

        public const decimal bulkPriceProductA = 3.00m;
        public const decimal bulkPriceProductB = 0;
        public const decimal bulkPriceProductC = 5.00m;
        public const decimal bulkPriceProductD = 0;

    }
}
