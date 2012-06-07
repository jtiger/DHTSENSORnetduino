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
Serial.print("Read Fail");
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
Serial.print("Read fail");
return NAN;
}

boolean DHT read(){
byte laststate=HIGH;
byte counter=0;
byte j=0;
byte i;
long currenttime;
//pull the pin high and wait 250 milliseconds








}