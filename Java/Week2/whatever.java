import java.util.Scanner;
import java.util.*;
class Alpha {
   public static void main(String[] args){
      Scanner scan = new Scanner(System.in);
      System.out.println("Enter a word: ");
      String word = scan.nextLine();
      System.out.println(word);
      //System.out.println("String Length = " + word.length);
      char g = word.charAt(0);
      char x =word.charAt(word.length() -1);
      System.out.println(g+((x-g)/2));
   }
}
