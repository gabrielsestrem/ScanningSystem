# ScanningSystem #
Scanning System Class Library

.NET Framework 4.7.2

Class library for a point-of-sale scanning system that accepts an arbitrary ordering of products, similar to what would happen at an actual checkout line, then returns the correct total price for an entire shopping cart based on per-unit or volume prices as applicable.

Here are the products listed by code and the prices to use. There is no sales tax.

Product Code | Unit Price | Bulk Price
--- | --- | --- 
A | $1.25 | 3 for $3.00 
B | $4.25 | 
C | $1.00 | $5 for a six-pack
D | $0.75 | 


# The class library #

1. Start Point: ScanningSystemClassLibrary.Start.StartCheckout(string[] items)
2. Business logic are implemented in the services/PointOfSaleTerminal.cs

# Running the tests #

Open Test Explorer in Visual Studio and run ScanningSystemTest
