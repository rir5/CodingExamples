#include<iostream>
using namespace std;
const int SIZE = 5;
int arn[SIZE];
void insertValues(int arn[SIZE]);
void displayValues(int arn[SIZE]);
void addValues(int arn[SIZE]);
void highValue(int arn[SIZE]);
static int size;
int userInput();
void bubbleSort();



int main(){
    cout << "Input size of Array: "<<endl;
    size = userInput();
    int numlist[size];
    for(int x = 0; x < size; x++){
        numlist[x] = userInput();
    }
    return 0;
}
void insertValues(int arn[SIZE]){
    int n;
    for(int i=0;i<SIZE;i++){
        cout<<"Enter #"<<endl;
        cin>>n;
        arn[i] = n;
    }
}
void displayValues(int arn[SIZE]){
    for(int i=0; i<SIZE;i++){
        cout<<"You Entered: "<<endl;
        cout<<arn[i]<<endl;
    }
}
void addValues(int arn[SIZE]){
    int total = 0;
    for(int i=0;i<SIZE;i++){
        total = total + arn[i];
        cout<<"Your sub-total is: "<<total<<endl;
    }
    cout<<"Your Total is: "<<total<<endl;
}
void highValue(int arn[SIZE]){
    int num = -1000;
    int num2 = -1000;
    
    for(int i=0;i<SIZE;i++){
        if(arn[i] > num){
            num = arn[i];
        }
    }
    for(int i=0;i<SIZE;i++){
        if(arn[i] > num2 && arn[i] != num){
            num2 = arn[i];
        }
    }
    cout<<"Your biggest number is: "<<num<<endl;
    cout<<"Your second biggest number is: "<<num2<<endl;
}

int userInput(){
    int dog;
    cout <<"Please input integer: "<< endl;
    cin >> dog;
    return dog;
}

void bubbleSort(int numlist[]){
    //int size = sizeof numlist;
    for(int x = 0; x < size; x++){
        for(int y = 0; y < size; y++){
            int temp = numlist[x];
            if(numlist[x] < numlist[y]){
                numlist[x] = numlist[y];
                numlist[y] = temp;
            }
            size--;
        }
    }
}