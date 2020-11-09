using RefrigeratorSimulator.Interfaces;

namespace RefrigeratorSimulator.Classes
{
    public class DefrostMachine : CameraDevice
    {
        public DefrostMachine()
        {
            Threshold = 80;
        }
    }
}
