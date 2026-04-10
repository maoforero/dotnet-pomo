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

        public void Restart(int seconds)
        {
            ArgumentNullException.ThrowIfNull(_session);
            ArgumentNullException.ThrowIfNull(_cts);
            _cts.Cancel();
            _session.RestartSession(seconds);
            _session = new PomodoroSession(seconds, true);

        }

        public void Cancel()
        {
            ArgumentNullException.ThrowIfNull(_cts);
            _cts.Cancel();
        }

        public void AddTime(int seconds)
        {
            ArgumentNullException.ThrowIfNull(_session);
            _session.UpdateTimeLimit(seconds);
        }

        public void DisableAlarm()
        {
            ArgumentNullException.ThrowIfNull(_session);
            _session.TurnOffAlarm();
        }
    }
}
