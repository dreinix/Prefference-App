#include <SPI.h>          // needed for Arduino versions later than 0018
#include <Ethernet.h>
#include <EthernetUdp.h>  // UDP library from: bjoern@cs.stanford.edu 12/30/2008


// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED }; //physical mac address
byte ip[] = { 192,168,1,112 }; // ip in lan
byte gateway[] = { 192,168,1,1  }; // internet access via router
byte subnet[] = { 255, 255, 255, 0 }; //subnet mask

unsigned int localPort = 8888;              // local port to listen on
int blue = 1, red = 2,yell=3,green=4;


// buffers for receiving and sending data
char packetBuffer[UDP_TX_PACKET_MAX_SIZE];  //buffer to hold incoming packet,
char  ReplyBuffer[] = "acknowledged";       // a string to send back

// An EthernetUDP instance to let us send and receive packets over UDP
EthernetUDP Udp;
int ActiveLed[10][1]; 
int Mode;

void setup() {
  // start the Ethernet and UDP:
  Ethernet.begin(mac, ip, gateway, subnet);
  Udp.begin(localPort);
  
  Serial.begin(9600);
  Serial.println("Esperando mensaje");
  defaultMode();
}


int GetMode(String data){
  //Serial.println("data val: ");
  
  String Sout = data.substring(0,1);
  int out = Sout.toInt();
  //Serial.println(Sout);
  return out;
}

void Turn(int val){
  digitalWrite(val,1);
}

void Shut(int val){
  digitalWrite(val,0);
}



int GetLed(String data){

// Serial.println("data val: ");
  
  String Sout = data.substring(2,3);
  int out = Sout.toInt();
  //Serial.println(Sout);
  return out;
}

int GetStatus(String data){
  
  //Serial.println("data val: ");
  
  String Sout = data.substring(4,5);
  int out = Sout.toInt();
  //Serial.println(Sout);
  return out;
}


void defaultMode(){
  for(int i=0;i<10;i++){
    Shut(i);
  }
}
void Static(){
  for(int i=0;i<10;i++){
    if(ActiveLed[i][0]==1){
      if(i==2){
        Turn(6);
      }
      Turn((i+2));
    }
  }
}
void Blink(){
  for(int i=0;i<10;i++){
    if(ActiveLed[i][0]==1){
      Turn(i+2);
    }
  }
  delay(500);
  for(int i=0;i<10;i++){
    if(ActiveLed[i][0]==1){
      Shut(i+2);
    }
  }
  delay(250);
}

void Cycle(){
  for(int i=0;i<10;i++){
    if(ActiveLed[i][0]==1){
      Turn(i+2);
      delay(500);
    }
    Shut(i+2);
    delay(300);
  }
}

void loop() {
  // if there's data available, read a packet
  int packetSize = Udp.parsePacket();
  
  switch(Mode){
    case 1:
    //Serial.println("Static");
      Static();
    break;
    case 2:
      Blink();
    break;
    case 3:
      Cycle();
    break;
  }
  
  if(packetSize)
  {
    Serial.print("From ");
    IPAddress remote = Udp.remoteIP();
    String ExternalIP="";
    for (int i =0; i < 4; i++)
    { 
      Serial.print(remote[i], DEC);
      ExternalIP+=remote[i];
      if (i < 3)
      {
        Serial.print(".");
        ExternalIP+=".";
      }
    }
    // read the packet into packetBufffer
    
    Udp.read(packetBuffer,UDP_TX_PACKET_MAX_SIZE);
    Serial.println("Contents:");
    String command = packetBuffer;
    
    //Serial.println(command);
      int value=GetMode(command);
      Serial.println("Input: ");
      Serial.println(value);
      if(value==1){
          Serial.println("MODE conf");      
          String Sout = command.substring(2,3);
          Mode = Sout.toInt();    
      }
      if(value==2){
          Serial.println("LED conf");          
          int color;
          color = GetLed(command);
          Serial.println(color);        
          ActiveLed[color][0]=GetStatus(command);
      }
  }
  delay(10);
}
