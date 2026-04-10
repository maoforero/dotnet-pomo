using System.Threading.Tasks;
using PomodoroTimer.Models;

namespace PomodoroTimer.Services
{
    public class TimerService
    {
        private CancellationTokenSource?   _cts;
        private PomodoroSession?           _session;

        public async Task StartAsync(int seconds, bool alarmState) 
        {
            _session = new PomodoroSession(seconds, alarmState);
            _cts = new CancellationTokenSource();

            while (!_cts.Token.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(1), _cts.Token);
                var now = DateTime.Now;

                if(now >= _session.TimeLimit)
                {
                    // Proceso de alarma en la UI
                    _cts.Cancel();
                }
                
            }
        }

        public async Task Restart(int seconds)
        {
            ArgumentNullException.ThrowIfNull(_session);
            ArgumentNullException.ThrowIfNull(_cts);
            var alarmState = _session.AlarmIsActive;
            _cts.Cancel();
            await StartAsync(seconds, alarmState);
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
