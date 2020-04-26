using ScanningSystemClassLibrary.Constants;
using ScanningSystemClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanningSystemClassLibrary
{
    public class PointOfSaleTerminal
    {
        private List<ProductPriceModel> SetPricing()
        {
            var productsPriceList = new List<ProductPriceModel>();

            foreach (var productCode in ProductsConstants.products)
            {
                var productPrice = new ProductPriceModel();

                // Setting product details
                switch (productCode)
                {
                    case ProductsConstants.productA:
                        productPrice.ProductName = ProductsConstants.productA;
                        productPrice.Price = ProductsConstants.priceProductA;
                        productPrice.HasBulkPrice = ProductsConstants.hasBulkPriceA;
                        productPrice.BulkPrice = ProductsConstants.hasBulkPriceA ? ProductsConstants.bulkPriceProductA : 0;
                        productPrice.BulkQuantity = ProductsConstants.hasBulkPriceA ? ProductsConstants.bulkItemProductA : 0;
                        break;
                    case ProductsConstants.productB:
                        productPrice.ProductName = ProductsConstants.productB;
                        productPrice.Price = ProductsConstants.priceProductB;
                        productPrice.HasBulkPrice = ProductsConstants.hasBulkPriceB;
                        productPrice.BulkPrice = ProductsConstants.hasBulkPriceB ? ProductsConstants.bulkPriceProductB : 0;
                        productPrice.BulkQuantity = ProductsConstants.hasBulkPriceB ? ProductsConstants.bulkItemProductB : 0;
                        break;
                    case ProductsConstants.productC:
                        productPrice.ProductName = ProductsConstants.productC;
                        productPrice.Price = ProductsConstants.priceProductC;
                        productPrice.HasBulkPrice = ProductsConstants.hasBulkPriceC;
                        productPrice.BulkPrice = ProductsConstants.hasBulkPriceC ? ProductsConstants.bulkPriceProductC : 0;
                        productPrice.BulkQuantity = ProductsConstants.hasBulkPriceC ? ProductsConstants.bulkItemProductC : 0;
                        break;
                    case ProductsConstants.productD:
                        productPrice.ProductName = ProductsConstants.productD;
                        productPrice.Price = ProductsConstants.priceProductD;
                        productPrice.HasBulkPrice = ProductsConstants.hasBulkPriceD;
                        productPrice.BulkPrice = ProductsConstants.hasBulkPriceD ? ProductsConstants.bulkPriceProductD : 0;
                        productPrice.BulkQuantity = ProductsConstants.hasBulkPriceD ? ProductsConstants.bulkItemProductD : 0;
                        break;
                    default:
                        break;
                }

                productsPriceList.Add(productPrice);
            }

            return productsPriceList;
        }


        public CheckOutItemModel ScanProduct(List<CheckOutItemModel> checkout, string product)
        {
            var priceList = SetPricing();
            var scannedProduct = new CheckOutItemModel();

            var existentItemInCheckout = checkout.Where(c => c.ProductName == product).FirstOrDefault();

            // Scanned Product already exists in the checkout list, add 1+ item to the scanned product model
            if (existentItemInCheckout != null)
            {
                scannedProduct.ProductName = existentItemInCheckout.ProductName;
                scannedProduct.Price = existentItemInCheckout.Price;
                scannedProduct.Quantity = existentItemInCheckout.Quantity + 1;

                return scannedProduct;
            }
            else
            {
                // Scanned Product does not exists in the checkout list, return scanned product model
                foreach (var item in priceList)
                {
                    if (product == item.ProductName)
                    {
                        scannedProduct.ProductName = item.ProductName;
                        scannedProduct.Price = item.Price;
                        scannedProduct.Quantity = 1;

                        return scannedProduct;
                    }
                } 
            }

            // Return empty object when product code does not exists in the price list
            return scannedProduct;
        }

        public decimal CalculateTotal(List<CheckOutItemModel> checkOutList)
        {
            decimal totalPrice = 0;
            var priceList = SetPricing();

            foreach (var item in checkOutList)
            {
                var itemDetails = priceList.Where(p => p.ProductName == item.ProductName).FirstOrDefault();

                if (itemDetails.HasBulkPrice)
                {
                    if (item.Quantity >= itemDetails.BulkQuantity)
                    {
                        // Bulk Price calculation
                        int bulkQuotient, bulkRemainder;
                        bulkQuotient = Math.DivRem(item.Quantity, itemDetails.BulkQuantity, out bulkRemainder);

                        decimal bulkCost = bulkQuotient * itemDetails.BulkPrice;
                        decimal remainderCost = bulkRemainder * item.Price;

                        totalPrice += bulkCost + remainderCost;
                        continue;
                    }
                }

                // Price Calculation
                totalPrice += item.Quantity * item.Price;

            }

            return totalPrice;
        }
    }
}
