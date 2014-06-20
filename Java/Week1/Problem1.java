import java.util.Scanner;
class Problem1{
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		String y = "";
		System.out.println("Input String: ");
		y = input.nextLine();
		System.out.println(DeCrack(y));
        	                
	}   
	public static String DeCrack(String y){ 
                String test = ""; 
		int div;
    
    
                int enNum = 4;//must be between 1-26 
    
                char[] got= new char[y.length()];
    
                for(int x = 0; x < y.length(); x++){
                        got[x] = y.charAt(x);
			if(((int)got[x]+enNum) > 122){
				got[x] += enNum - 26;
			}
			else if(((int)got[x]+enNum) > 90 && ((int)got[x]+enNum)<97){ 
                                got[x] += enNum - 26;
                        }   
			else if(Character.isLetter(got[x])){
                                got[x] +=enNum;//subtracts encryption value to decrypt
                        }   
                        test += got[x];//makes string value of array of chars
                }   
		System.out.println(Character.getNumericValue('a'));
		System.out.println(Character.getNumericValue('z'));
		System.out.println('z' + 2);
                return test;//returns value
	}   
}
