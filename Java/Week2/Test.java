import java.util.*;
class test1{
	@SuppressWarnings("all")
	public static void main(String[] args){
		//int[] x = {1,2,3,4};
		// create an array list
      		//ArrayList al = new ArrayList();
		List<String> al= new ArrayList<String>();
		try{
      			System.out.println("Initial size of al: " + al.size());
			al.add("A");
      			al.add("B");
      			al.add("C");
      			al.add("D");
      			al.add("E");
      			al.add("F");
			al.add(0, "0");
			System.out.println("Contents of al: " + al);
		}
		catch(Exception e){
			System.out.println("Game");
		}	
	}
}
