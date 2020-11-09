using RefrigeratorSimulator.Interfaces;
using System.Media;

namespace RefrigeratorSimulator.Classes
{
    public class Speaker : INotify
    {
        public void Notify()
        {
            SystemSounds.Beep.Play();
        }
    }
}