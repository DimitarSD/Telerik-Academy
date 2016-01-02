package reverser;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class StartUp {

	public static void main(String[] args) throws IOException {
		System.out.print("Enter a word: ");
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		
		String userInput = br.readLine();
		
		StringBuilder builder = new StringBuilder();
		
		for (int i = userInput.length() - 1; i >= 0; i--) {
			builder.append(userInput.charAt(i));
		}
		
		System.out.println("Reserved word: " + builder.toString());
	}

}
