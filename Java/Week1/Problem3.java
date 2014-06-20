class Problem3{
	public static void main(String [] args){
		String x = "Good";	
		String ex = reV(x);
		System.out.println(ex);
		if(ex.compareTo(x) == 0){
			System.out.println("Is a palindrome");
		}

	}
	public static String reV(String word){
		if(word.length() == 0)
			return word;	
		return reV(word.substring(1)) + word.charAt(0);

	}
}
