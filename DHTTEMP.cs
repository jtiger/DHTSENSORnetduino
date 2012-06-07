using DHTSENSOR;


void DHT(begin()){
//set up pins




}

//boolean S ==Scale. True == Farenheit False==Celcius

float DHT readTemperature( ){
    float f;

if (read()){
    switch(_type){
    case DHT11:
        f=data[2];
        if(S)
        f=convertCtoF(f);
        return f;
    case DHT22:
    case DHT21:
        f=data[2] & 0x7F;
        f*=256;
        f+=data[3];
        f/=10;
        if(data[2] & 0x80)
            f*=-1;
        if(S)
            f=convertCtoF(f);
        return f;
    
}
Debug.Print("Read Fail");
return NAN;
}

float DHT convertCtoF(float c) {
    return c*(9/5)+32;
}
}

float DHT readHumidity(void) {
    float f;
    if (read()){
        switch(_type){
        case DHT11:
            f=data[0];
            return f;
        case DHT22:
        case DHT21:
            f=data[0];
            f*=256;
            f+=data[1];
            f/=10;
            return f;
    }
}
Debug.Print("Read fail");
return NAN;
}

boolean DHT read(){
byte laststate=HIGH;
byte counter=0;
byte j=0;
byte i;
long currenttime;
//pull the pin high and wait 250 milliseconds

digitalWrite(_pin, HIGH);
Thread.Sleep(250);

currenttime=millis();
if (currenttime<_lastreadtime){
    //ie there was a rollover
    _lastreadtime=0;
    }
if (!firstreading && ((currenttime-_lastreadtime)<2000)){
    return true; 
    //return last correct measurement
    //delay(2000-(currenttime-_lastreadtime));
}
firstreading=false;

Debug.print("Currtime: ");
Debug.print(currenttime);
Debug.print("Lasttime: ");
Debug.print(_lastreadtime);

_lastreadtime=millis();

data[0]=data[1]=data[2]=data[3]=data[4]=0;

//pull low for 20 millsecounds

pinMode(_pin,OUTPUT);
digitalWrite(_pin,LOW);
Thread.Sleep(20);
cli();
digitalWrite(_pin, HIGH);
Thread.Sleep(.004);  //delay for 40 ms
pinMode(_pin,INPUT);


//read in timings

for (i=0; i<MAXTIMINGS; i++){
    counter=0;
    


}







}