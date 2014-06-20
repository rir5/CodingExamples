class Problem2{
	public static void main(String [] args){
		int end = 100000;
		int start = 999996;
		int old = 0;
		int answer = 0;
		char[] num = new char[6];
		boolean f1=false;
		boolean f2=false;
		boolean f3=false;
		boolean f4=false;
		boolean f5=false;
		while(end != start){
			num = ("" + start).toCharArray();
			if((num[0]==num[5] && num[1] == num[4] && num[2] == num[3]) || f1){
				f1=true;
				if((num[1]==num[4] && num[2] == num[3]) || f2){
					f2=true;
					if((num[1]==num[5] && num[2]==num[4] && num[3]!=num[2] && num[3]!=num[4]) || f3){
						f3=true;
						if((num[2]==num[5] && num[3]==num[4])){
							//System.out.println(start);
							if(old<start){
								old++;
							}
							answer=start;
							f1=false;
							f2=false;
							f3=false;
						}
						else{
							//System.out.println("-1");
						}
					}

				}
			}		
			start--;
		}
		System.out.println(answer);

	}
}
