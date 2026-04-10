namespace PomodoroTimer.Models
{
    public class PomodoroSession
    {
        public int AmountOfSeconds { get; private set; }
        public bool AlarmIsActive { get; private set; }
        public DateTime TimeLimit { get; private set; }

        public PomodoroSession(int timer, bool alarm)
        {
            AmountOfSeconds = timer;
            AlarmIsActive = alarm;
            TimeLimit = DateTime.Now.AddSeconds(timer);
        }

        public void TurnOffAlarm()
        {
            AlarmIsActive = false;
        }


        public void UpdateTimeLimit(int timer)
        {
            AmountOfSeconds += timer;
            TimeLimit = TimeLimit.AddSeconds(timer);
        }

        public void RestartSession(int newTimer)
        {
            AmountOfSeconds = newTimer;
            TimeLimit = DateTime.Now.AddSeconds(AmountOfSeconds);
        }
    }
}
