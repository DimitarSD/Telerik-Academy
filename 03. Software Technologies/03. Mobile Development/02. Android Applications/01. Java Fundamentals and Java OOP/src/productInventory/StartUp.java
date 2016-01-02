package productInventory;

import java.util.Random;

public class StartUp {

	public static void main(String[] args) {
		Product[] products = generateRandomProducts();
		Inventory inventory = new Inventory();
		inventory.add(products);
		
		String totalPrice = String.format("%.2f", (double)inventory.sumProductsPrice());
		
		System.out.println("Price of all products: $" + totalPrice);
		System.out.println("Quantity of all products: " + inventory.sumProductsQuantity());
	}
	
	private static Product[] generateRandomProducts() {
		Product[] products = new Product[25];
		Random randomPrice = new Random();
		Random randomQuantity = new Random();
		
		for (int i = 0; i < products.length; i++) {
			double price = randomPrice.nextDouble() + 25;
			int quantity = randomQuantity.nextInt(10);
			
			products[i] = new Product(price, quantity);
		}
		
		return products;
	}

}
