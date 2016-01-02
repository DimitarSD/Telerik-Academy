package productInventory;

import java.util.ArrayList;
import java.util.List;

public class Inventory {
	private List<Product> inventory;
	
	public Inventory() {
		this.inventory = new ArrayList<Product>();
	}
	
	public void add(Product product) {
		this.inventory.add(product);
	}
	
	public void add(Product[] products) {
		for (int i = 0; i < products.length; i++) {
			this.inventory.add(products[i]);
		}
	}
	
	public int sumProductsQuantity() {
		int sum = 0;
		
		for (int i = 0; i < this.inventory.size(); i++) {
			int productQuantity = inventory.get(i).getQuantity();
			sum += productQuantity;
		}
		
		return sum;
	}
	
	public double sumProductsPrice() {
		double sum = 0;
		
		for (int i = 0; i < this.inventory.size(); i++) {
			double productPrice = inventory.get(i).getPrice();
			sum += productPrice;
		}
		
		return sum;
	}
}
