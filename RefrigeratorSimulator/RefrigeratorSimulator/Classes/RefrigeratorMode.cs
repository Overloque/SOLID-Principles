using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RefrigeratorSimulator.Classes
{
    public class RefrigeratorMode
    {
        public RefrigeratorMode(string name, double heatTemperature, double coolTemperature)
        {
            Name = name;
            HeatTemperature = heatTemperature;
            CoolTemperature = coolTemperature;
        }

        public string Name { get; }
        public double HeatTemperature { get; }
        public double CoolTemperature { get; }
    }

    public static class RefrigeratorModeProvider
    {
        private static ObservableCollection<RefrigeratorMode> refrigeratorModes;

        public static ObservableCollection<RefrigeratorMode> RefrigeratorModes {
            get
            {
                refrigeratorModes ??= GetRefrigeratorModes();
                return refrigeratorModes;
            }
        }
        private static ObservableCollection<RefrigeratorMode> GetRefrigeratorModes()
        {
            var refrigeratorModes = new ObservableCollection<RefrigeratorMode>();
            var modes = new List<(string, double, double)>
            {
                ("Стандартный режим", 1, -1),
                ("Быстрая заморозка", 1, -3),
                ("Разморозка", 5, -1),
                ("Оттаивание", 3, -1),
            };

            foreach (var (name, heatTemperature, coolTemperature) in modes)
            {
                var refrigeratorMode = new RefrigeratorMode(name, heatTemperature, coolTemperature);
                refrigeratorModes.Add(refrigeratorMode);
            }

            return refrigeratorModes;
        }
    }
}