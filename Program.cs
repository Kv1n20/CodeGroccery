using CodeGroccery;
using System.ComponentModel;
using System.Linq;

//initalize array of stocked items
Product[] productArray = new Product[4];
productArray[0] = new Product("A99", 50, 3, 130);
productArray[1] = new Product("B15", 30, 2, 45);
productArray[2] = new Product("C40", 60);
productArray[3] = new Product("T34", 99);

//data structure to hold checkout data
List<checkoutItem> shoppingCart = new List<checkoutItem>();

Console.WriteLine("Welcome to the Checkout, Please Scan a barcode to begin: ");
string barcode = Console.ReadLine();
while (barcode != "checkout"){
    //check if barcode was added to checkout array
    bool Added = false;
    foreach (checkoutItem item in shoppingCart)
    {
        if (barcode.Equals(item.getItem())) {
            item.addItem();
            Added = true;
            break;
        }
    }
    //else check if it is valid
    if (!Added) {
        foreach (Product item in productArray)
        {
            if (item.validSKU(barcode)) {
                shoppingCart.Add(new checkoutItem(barcode)); //this line isn't working
                Added = true;
                break;
            }
        } 
    }

    //otherwise print error msg, ask for new barcode
    if (Added)
    {
        Console.WriteLine("Item Added, Please Scan another barcode, or type checkout to exit: ");

    }
    else
    {
        Console.WriteLine("Invalid Barcode, Please Scan another barcode, or type checkout to exit: ");
    }
    barcode = Console.ReadLine();
}
//price calcluation here
float totalCost = 0;
Console.WriteLine("Your shopping cart:");
foreach (checkoutItem item in shoppingCart)
{
    string sku = item.getItem();
    Console.WriteLine("SKU:" + sku + ", amount:" + item.getQuantity());
    foreach (Product stockedProduct in productArray)
    {
        if (stockedProduct.validSKU(sku))
        {
            totalCost = totalCost + stockedProduct.getCost(item.getQuantity());
            Console.WriteLine("Item Added:" + sku);
            Console.WriteLine("New Price:" + totalCost);
            break;
        }
    }
}

 
Console.WriteLine("Your total cost:" + totalCost);
