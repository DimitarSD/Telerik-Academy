package randomGiftSuggestions;


public class Gift {
	private String name;
	private String place;
	
	public Gift(String name, String place) {
		this.setName(name);
		this.setPlace(place);
	}
	
	String getName() {
		return this.name;
	}
	
	void setName(String value) {
		this.name = value;
	}
	
	String getPlace() {
		return this.place;
	}
	
	void setPlace(String value) {
		this.place = value;
	}
}
