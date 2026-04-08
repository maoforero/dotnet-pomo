namespace PomodoroTimer.Models
{
    public class PomodoroSession
    {
        public DateTime Now { get; private set; }
        public int AmountTime { get; private set; }
        public bool Alarm { get; private set; }

        public PomodoroSession(DateTime now, int timer, bool alarm)
        {
            Now = now;
            AmountTime = timer;
            Alarm = alarm;
        }

        public void ActivateAlarm(bool state)
        {
            Alarm = state;
        }
    }
}
