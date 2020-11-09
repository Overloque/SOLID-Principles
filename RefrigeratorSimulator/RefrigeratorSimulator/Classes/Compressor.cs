using RefrigeratorSimulator.Interfaces;

namespace RefrigeratorSimulator.Classes
{
    public class Compressor : CameraDevice
    {
        public Compressor() 
        { 
            Threshold = 90; 
        }
    }
}