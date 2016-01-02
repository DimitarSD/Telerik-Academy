package countWords;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class StartUp {
	
	private static final String PATH = "./src/countWords/text.txt";
	
	public static void main(String[] args) throws IOException {
		System.out.println("The text file is located in \"countWords\" folder :)");
		List<String> textData = Files.readAllLines(Paths.get(PATH), StandardCharsets.UTF_8);
		
		String userInput = textData.toString();
		
		// Next line is used to remove the [] from the file.
		userInput = userInput.substring(1, userInput.length() - 1);
				
		String[] userInputSeparated = userInput.split("[\\s;.<>|/,:'!?()-]");
		
		Map<String, Integer> dictionary = new HashMap<String, Integer>();
		
		for (int i = 0; i < userInputSeparated.length; i++) {
			String word = userInputSeparated[i];
			
			if (dictionary.containsKey(word)) {
				Integer occuranceOfWord = dictionary.get(word);
				occuranceOfWord++;
				dictionary.put(word, occuranceOfWord);
			} else {
				dictionary.put(word, 1);
			}
		}
		
		for (Map.Entry<String, Integer> entry : dictionary.entrySet()) {
		    String key = entry.getKey();
		    Integer value = entry.getValue();
		    System.out.println("Occurances: " + value + " | " + key);
		}
	}
}
