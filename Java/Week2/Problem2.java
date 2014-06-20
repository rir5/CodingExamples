import java.util.*;
class Problem2{
	public static void main(String[] args){
		int[] x = {7,22,13,4,18,21,6,8};
		List<Integer> arList = new ArrayList<Integer>();
		arList = add(x);
		//System.out.println(check(arList));
		System.out.println("Contents of arList: " + reCurse(arList,0,arList.size(),1,0));
	}
	public static boolean check(List<Integer> x){
		int z = 0;
		for(int g = 1;g<x.size();g++){
			if(z==3){
				return false;
			}
                        if((x.get(g-1)%2 > 0) != !(x.get(g)%2==0))
                        	z++;
		}
		System.out.println(z);
		return true;

	}
	public static List<Integer> reCurse(List<Integer> x, int z, int size, int g,int j){
		System.out.println(j);
		if(z == size ||(j<3 && g==x.size())){
			return x;
		}
		if((x.get(g-1)%2 > 0) != !(x.get(g)%2==0))
			j++;
		if(j>=3 && x.get(z)%2 > 0){
			x.add(x.get(z));
			x.remove(z);
			size--;
			return reCurse(x,z,size,g,j);
		}
		if(j>=3)
			return reCurse(x,z+1,size,g,j);
		 return reCurse(x,z,size,g+1,j);
	}
	public static List<Integer> add(int a[]){
		List<Integer> ls = new ArrayList<Integer>();
		for(int x = 0; x < a.length; x++){
			ls.add(a[x]);
		}
		return ls;
	}

}
//Problem #3
//the min = 3 for checking algorithm and 0 for recursive algorithm 
//the max = 7 for checking algorithm and 9 for recursive algorithm
