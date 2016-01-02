package randomGiftSuggestions;

import java.util.Random;

public class StartUp {

	private static Gift[] gifts;
	
	public static void main(String[] args) {
		String[] people = new String[] {"Albena", "Georgi", "Vasil"};
		seedGifts();
		
		for (int i = 0; i < people.length; i++) {
			Gift gift = getRandomGift();
			String person = people[i];
			
			System.out.println(person + ": Gift - " + gift.getName() + " | Place to buy - " + gift.getPlace());
		}
	}

	private static Gift getRandomGift() {
		Random random = new Random();
		Integer index = random.nextInt(gifts.length);
		
		return gifts[index];
	}
	
	private static void seedGifts() {
		gifts = new Gift[] {
				new Gift("Ball", "Decatlon, Sofia"),
				new Gift("Laptop", "Tehnomarket, Sofia"),
				new Gift("Book", "Hermes, Sofia"),
				new Gift("Iphone 6S Plus", "Apple Store, Sofia"),
				new Gift("Camera", "Tehnomarket, Sofia"),
				new Gift("Bicycle", "Decatlon, Sofia"),
				new Gift("Laptop", "Tehnomarket, Sofia"),
				new Gift("Board game", "Orange, Sofia"),
				new Gift("MacBook Air", "Apple Store, Sofia"),
				new Gift("Samsung S6", "Samsung Market, Sofia")
		};
	}
}
