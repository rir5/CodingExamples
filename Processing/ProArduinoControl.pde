import processing.serial.*;
Serial myPort;

void setup(){
  // The serial port:
  //Serial myPort;

  // List all the available serial ports:
  println(Serial.list());

  // Open the port you are using at the rate you want:
  myPort = new Serial(this, "COM3", 9600);

  // Send a capital "A" out the serial port
  //example: myPort.write(65);
  
}

void draw() { 
  // keep draw() here to continue looping while waiting for keys
  //println(myPort.read());
}

void keyPressed() {
  if(key == 'w' || keyCode == UP){
    println("forward");
     //forward code;
     myPort.write('1');
  }  
  if(key == 's' || keyCode == DOWN){
    println("backward");
    //backward code;
    myPort.write('2');
  }
  if(key == 'a' || keyCode == LEFT){
    println("leftward");
    //leftward code;
    myPort.write('3');
  }
  if(key == 'd' || keyCode == RIGHT){
    println("rightward");
    //rightward code;
    myPort.write('4');
  }
}
