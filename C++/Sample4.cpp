#include <iostream>
#include <string>
using namespace std;
bool comString();

int main(){
	cout<<comString()<<endl;
	return 0;
}
bool comString(){
	bool gar;
	string xmen;
	string ymen;
	char a[100];
	char b[100];
	cout<<"Enter two lines of input for comparision:"<<endl;
	getline(cin,xmen);
	getline(cin,ymen);
	xmen.erase(remove(xmen.begin(), xmen.end(), ' '), xmen.end());
	ymen.erase(remove(ymen.begin(), ymen.end(), ' '), ymen.end());
	strcpy(a,xmen.c_str());
	strcpy(b,ymen.c_str());
	for(int x=0;x<xmen.length();x++){
		a[x] = tolower(a[x]);
	}
	for(int x=0;x<ymen.length();x++){
		b[x] = tolower(b[x]);
	}
	string srt(a);
	string src(b);
	cout<<srt<<endl;
	cout<<src<<endl;
	if(srt == src){
		gar = true;
	}
	if(srt != src){
		gar = false;
	}
	return gar;
}
