using PomodoroTimer.Services;

namespace PomodoroTimer.UI
{
    public class ConsoleRenderer
    {
        private readonly ITimerService _timerService;
        private static readonly SemaphoreSlim _consoleLock = new(1,1);

        private const string DIM1 = "\x1b[38;2;0;26;0m";      // #001a00
        private const string DIM2 = "\x1b[38;2;0;51;0m";       // #003300
        private const string DIM3 = "\x1b[38;2;0;85;0m";       // #005500
        private const string BASE = "\x1b[38;2;0;170;68m";     // #00aa44
        private const string BRIGHT = "\x1b[38;2;0;204;85m";     // #00cc55
        private const string WHITE = "\x1b[38;2;0;255;102m";    // #00ff66
        private const string RESET = "\x1b[0m";

        public ConsoleRenderer(ITimerService timer)
        {
            _timerService = timer;
        }

        public async Task UiRendererProcess()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            while (!_timerService.IsCompleted)
            {
                Console.SetCursorPosition(0, 0);
                await Task.Delay(1000);
            }

        // 1. configuración inicial de la consola
        // 2. loop de redibujado
        //    - leer estado del timerService
        //    - redibujar UI
        //    - esperar 1 segundo
        //    - verificar si completó para detener el loop
        }

        private void RendererHeader() { }
        private void RendererTimer() { }

        private void RendererButtons() { }
    }
}
