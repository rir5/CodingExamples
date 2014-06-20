//
//  File.cpp
//  DelriusHW
//
//  Created by Rafy I Reyes on 11/12/13.
//  Copyright (c) 2013 Rafy I Reyes. All rights reserved.
//

#include <iostream>
using namespace std;

void displaySeats();

int main(){
    displaySeats();
    
    
    return 0;
}

void displaySeats(){
	char letter;
	int num;
	char a[7][4]={};
	for(int g = 0; g<4; g++){
		char a[7][g]={'A','B','C','D'};
	}
	cout <<"Input #: "<<endl;
	cin>> num;
    	num = num - 1;
	cout <<"Input Letter: "<<endl;
	cin>> letter;
	for(int x = 0; x<7; x++){
		for(int y =0; y<4; y++){
			cout << a[x][y];
		}
		cout<<endl;
	}
    for(int x = 0; x < 4; x++){
		if(a[num][x] == letter){
			a[num][x] = 'X';
		}
		else{
			cout << "Seat Not Found or Taken!";
		}
	}
}
/*void SearchDestroy(char a[][], int num, char letter){
	for(int x = 0; x < 4; x++){
		if(a[num][x] == letter){
			a[num][x] = 'X';
		}
		else{
			cout << "Seat Not Found or Taken!";
		}
	}
	return a;
}*/
