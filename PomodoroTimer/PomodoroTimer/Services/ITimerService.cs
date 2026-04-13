namespace PomodoroTimer.Services
{
    public interface ITimerService
    {
        Task StartAsync(int seconds, bool alarmState);
        Task Restart(int seconds);
        void Cancel();
        void AddTime(int seconds);
        void DisableAlarm();
        TimeSpan Remaining { get; }
        bool AlarmIsActive { get; }
        int TotalSeconds { get; }
        bool IsCompleted { get; }
    }
}
