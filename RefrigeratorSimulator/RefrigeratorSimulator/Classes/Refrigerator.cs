using RefrigeratorSimulator.Interfaces;
using System.Collections.ObjectModel;
using System.Timers;

namespace RefrigeratorSimulator.Classes
{
    public class Refrigerator
    {
        public readonly int TimeInterval = 1;
        
        public Refrigerator()
        {
            Notifier = new Speaker();
            StandardMicroprocessors = new ObservableCollection<Microprocessor>();
            FreezerMicroprocessors = new ObservableCollection<Microprocessor>();

            for (int i = 0; i < 5; i++)
            {
                StandardMicroprocessors.Add(new Microprocessor($"Холодильная камера {i + 1}", 4, Notifier));
            }

            for (int i = 0; i < 2; i++)
            {
                FreezerMicroprocessors.Add(new Microprocessor($"Морозильная камера {i + 1}", -19, Notifier));
            }
        }

        public ObservableCollection<Microprocessor> StandardMicroprocessors { get; }
        public ObservableCollection<Microprocessor> FreezerMicroprocessors { get; }

        public INotify Notifier { get; }

        private void UpdateTemperatures()
        {
            foreach (var standardMicroprocessor in StandardMicroprocessors)
            {
                standardMicroprocessor.UpdateTemperature();
            }
            foreach (var freezerMicroprocessor in FreezerMicroprocessors)
            {
                freezerMicroprocessor.UpdateTemperature();
            }
        }

        public void OnElapsed(object source, ElapsedEventArgs e)
        {
            UpdateTemperatures();
        }
    }
}