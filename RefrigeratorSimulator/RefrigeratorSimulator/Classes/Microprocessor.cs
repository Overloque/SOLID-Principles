using RefrigeratorSimulator.Interfaces;

namespace RefrigeratorSimulator.Classes
{
    public class Microprocessor
    {
        private INotify notifier;

        public Microprocessor(string name, double temperature, INotify notifier)
        {
            Name = name;
            Camera = new Camera(temperature);
            Temperature = temperature;
            RefrigeratorMode = RefrigeratorModeProvider.RefrigeratorModes[0];
            Compressor = new Compressor() { Camera = Camera };
            DefrostMachine = new DefrostMachine() { Camera = Camera };
            this.notifier = notifier;
        }
        public string Name { get; set; }
        public CameraDevice Compressor { get; }
        public CameraDevice DefrostMachine { get; }
        public Camera Camera { get; }
        public RefrigeratorMode RefrigeratorMode { get; set; }

        /// <summary>
        /// Заданная температура
        /// </summary>
        public double Temperature { get; set; }

        public void UpdateTemperature()
        {
            if (Camera.Temperature > Temperature)
            {
                Compressor.UpdateTemperature(RefrigeratorMode.CoolTemperature);
            }
            else if (Camera.Temperature < Temperature)
            {
                DefrostMachine.UpdateTemperature(RefrigeratorMode.HeatTemperature);
            }
            if (Compressor.Temperature >= Compressor.Threshold)
            {
                Compressor.Enabled = false;
                notifier.Notify();
            }
            if (DefrostMachine.Temperature >= DefrostMachine.Threshold)
            {
                DefrostMachine.Enabled = false;
                notifier.Notify();
            }
        }
    }
}