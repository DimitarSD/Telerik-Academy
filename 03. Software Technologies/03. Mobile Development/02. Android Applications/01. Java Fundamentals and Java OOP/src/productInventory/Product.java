package productInventory;

import java.util.UUID;

public class Product {
	private long id;
	private double price;
	private int quantity;
	
	public Product(double price, int quantity) {
		this.id = UUID.randomUUID().getMostSignificantBits();
		this.setPrice(price);
		this.setQuantity(quantity);
	}
	
	public long getId() {
		return this.id;
	}
	
	public double getPrice() {
		return this.price;
	}
	
	public void setPrice(double value) {
		if (value < 0) {
			throw new IllegalArgumentException("Price cannot be less than 0");
		}
		
		this.price = value;
	}
	
	public int getQuantity() {
		return this.quantity;
	}
	
	public void setQuantity(int value) {
		if (value < 0) {
			throw new IllegalArgumentException("Quantity cannot be less than 0");
		}
		
		this.quantity = value;
	}
}
