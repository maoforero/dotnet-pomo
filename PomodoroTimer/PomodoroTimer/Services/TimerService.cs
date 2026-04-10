using PomodoroTimer.Models;

namespace PomodoroTimer.Services
{
    public class TimerService
    {
        private CancellationTokenSource? _cts;
        private  PomodoroSession? _session;

        public async Task StartAsync(int seconds, bool alarmState) 
        {
            _session = new PomodoroSession(seconds, alarmState);
        }

        public void Restart()
        {
            ArgumentNullException.ThrowIfNull(_session);
        }

        public void Cancel()
        {
            ArgumentNullException.ThrowIfNull(_session);
        }

        public async Task AddTimeAsync(int seconds)
        {
            ArgumentNullException.ThrowIfNull(_session);
            _session.UpdateTimeLimit(seconds);
        }

        public async Task DisableAlarm()
        {
            ArgumentNullException.ThrowIfNull(_session);
        }
    }
}
