using System.Timers;

namespace RefrigeratorSimulator
{
    public class RefrigeratorViewModel
    {
        public RefrigeratorViewModel()
        {
            Refrigerator = new Classes.Refrigerator();
            var timer = new Timer(Refrigerator.TimeInterval * 1000);
            timer.Elapsed += Refrigerator.OnElapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public Classes.Refrigerator Refrigerator { get; set; }
    }
}