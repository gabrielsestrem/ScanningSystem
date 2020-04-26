using ScanningSystemClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanningSystemClassLibrary
{
    public class Start
    {
        public static decimal StartCheckout(string[] products)
        {
            var terminal = new PointOfSaleTerminal();

            var checkOutList = new List<CheckOutItemModel>();

            foreach (var product in products)
            {
                // Scanning each product from the current order
                var scannedProduct = terminal.ScanProduct(checkOutList, product);

                if (scannedProduct.Quantity == 0)
                {
                    // Skip product if does not exists in the price list
                    continue;
                }
                if (scannedProduct.Quantity == 1)
                {
                    // Adding scanned product into the checkout list
                    checkOutList.Add(scannedProduct);
                }
                else
                {
                    // Edit the checkout list, adding scanned product to the existent item
                    checkOutList[checkOutList.FindIndex(checkout => checkout.ProductName.Equals(scannedProduct.ProductName))] = scannedProduct;
                }


            }

            decimal result = terminal.CalculateTotal(checkOutList);


            return result;
        }
    }
}
