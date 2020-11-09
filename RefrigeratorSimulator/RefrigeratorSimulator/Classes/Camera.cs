using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RefrigeratorSimulator.Classes
{
    public class Camera : INotifyPropertyChanged
    {
        private double temperature;
        public Camera(double temperature)
        {
            Temperature = temperature;
        }

        /// <summary>
        /// Текущая температура
        /// </summary>
        public double Temperature 
        {
            get
            {
                return temperature;
            }
            set
            {
                if (temperature.Equals(value))
                {
                    return;
                }

                temperature = value;
                RaisePropertyChanged();
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}