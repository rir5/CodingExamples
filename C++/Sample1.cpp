#include "File.h"
#include <iostream>
using namespace std;

int main(){
    int i=0;
    char a[] = "the elphant ate a dog";
    if(isupper(a[i])){
                      a[i] = toupper(a[i]);
    }
    if(islower(a[i])){
        a[i] = toupper(a[i]);
    }
    string str(a);
    cout<<a<<endl;
    return 0;
    
}
