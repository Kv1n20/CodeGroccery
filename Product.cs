using System;
using System.Diagnostics;
namespace CodeGroccery;

public class Product
{
	private string SKU;
	private float unitPrice;
	private bool onOffer;
	private int offerQuantity;
	private float offerPrice;
	public Product(string SKUName, float price)
	{
		this.SKU = SKUName;
		this.unitPrice = price;
		onOffer = false;
		offerPrice = 0;
		offerQuantity = 0;
	}
	public Product(string SKUName, float price, int offerNumber, float offerCost)
	{
		this.SKU = SKUName;
		this.unitPrice = price;
		this.offerQuantity = offerNumber;
		this.offerPrice = offerCost;
		onOffer = true;

	}
	public bool validSKU(string SKUName)
	{
		return this.SKU.Equals(SKUName);
	}

	public bool offerExists()
	{
		return this.onOffer;
	}

	public float getCost(int itemCount)
	{
		if ((itemCount >= this.offerQuantity) && onOffer)
		{
			int noOfferCount = itemCount % this.offerQuantity;
			int offerCount = (itemCount - noOfferCount) / offerQuantity;
			float noOfferCost = noOfferCount * unitPrice;
			float offerCost = offerCount * offerPrice;
			return (noOfferCost + offerCost);
		}
		else
		{
			return unitPrice * itemCount;
		}
	}

	public void stopOffer()
	{
		onOffer = false;
		offerPrice = 0;
		offerQuantity = 0;
	}

	public void addOffer(int itemCount, float offerCost)
	{
		onOffer = true;
		this.offerPrice = offerCost;
		this.offerQuantity = itemCount;
	}

	public void updatePrice(float cost)
	{
		this.unitPrice = cost;
	}
}