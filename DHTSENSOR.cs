using System;
using Microsoft.SPOT;

namespace DHTSENSOR
{
       
    public class DHT
     
    {
         public DHT(byte pin, byte type);
         public void begin();
         public float readTempature(Boolean S=false);
         public float convertCtoF();
         public float readHumidity();
     
        private fixed data[6];
        private byte _pin;
        private Boolean read();
        private long _lastreadtime;
        private Boolean firstreading;
     }


    
    
}
