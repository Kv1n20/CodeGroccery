using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CodeGroccery;
public class checkoutItem
{
    private string item;
    private int quantity;
    public checkoutItem(string SKU)
    {
        this.item = SKU;
        this.quantity = 1;

    }
    public void addItem()
    {
        quantity = quantity+1;
    }

    public string getItem() { return item; }
    public int getQuantity() { return quantity; }
}


