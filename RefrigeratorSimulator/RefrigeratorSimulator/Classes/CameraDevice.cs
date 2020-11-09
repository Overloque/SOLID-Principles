using RefrigeratorSimulator.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RefrigeratorSimulator.Classes
{
    public abstract class CameraDevice : INotifyPropertyChanged, ITemperatureController
    {
        public int Threshold { get; set; }
        private double temperature = 60;
        public Camera Camera { get; set; }
        public bool Enabled { get; set; } = true;
        public double Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value < 60)
                {
                    if (Enabled == false)
                    {
                        Enabled = true;
                    }
                    return;
                }

                temperature = value;
                RaisePropertyChanged();
            }
        }
        protected void UpdateMechanismTemperature()
        {
            if (Enabled)
            {
                Temperature += 1;
            }
            else
            {
                Temperature -= 1;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateTemperature(double deltaTemperature)
        {
            if (Enabled)
            {
                Camera.Temperature += deltaTemperature;
            }

            UpdateMechanismTemperature();
        }
    }
}
