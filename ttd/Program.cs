using System.Diagnostics;
using ttd.Render;

namespace ttd;

internal static class Program
{
    // Spinner characters
    private static readonly char[] Spinner = ['|', '/', '-', '\\'];
    private const int Cols = 150;
    private const int Rows = 40;
    private static readonly Random Random = new Random();
    private static readonly Screen Screen = new Screen(Cols, Rows);
    private static readonly Color Green = new Color(0, 255, 0);
    private static readonly Color Black = new Color(0, 0, 0);
    private static readonly Color White = new Color(255, 255, 255);
    private static bool _isRunning = true;

    private static char RandomChar() => (char)(Random.Next(94) + 33);

    private static Color RandomColor() =>
        new Color((byte)Random.Next(256), (byte)Random.Next(256), (byte)Random.Next(256));

    private static void RenderFps(double fps)
    {
        Screen.Draw(2, 0, $"FPS: {fps:F2}", Green, Black);
    }

    private static void RenderRandomChars()
    {
        for (int i = 0; i < 500; i++)
        {
            int y = Random.Next(Rows) + 1;
            int x = y == 1 ? Random.Next(Cols - 14) + 15 : Random.Next(Cols) + 1;
            Color foreground = RandomColor();
            Color background = RandomColor();
            Screen.Draw(x, y, RandomChar(), foreground, background);
        }
    }

    private static void RegisterShutdownHook()
    {
        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true;
            _isRunning = false;
        };
    }

    public static void Main(string[] args)
    {
        int frameCount = 0;
        var stopwatch = new Stopwatch();
        int sbLength = 0;
        
        const int bufferSize = 32000;
        using var outs = new StreamWriter(Console.OpenStandardOutput(), bufferSize: bufferSize);

        RegisterShutdownHook();
        Screen.SetAlternateScreenBuffer();
        stopwatch.Start();

        while (_isRunning)
        {
            stopwatch.Stop();
            double elapsedTime = stopwatch.Elapsed.TotalSeconds;
            stopwatch.Restart();

            double fps = 1.0 / elapsedTime;

            RenderRandomChars();
            frameCount++;
            char spinnerChar = Spinner[frameCount % Spinner.Length];
            Screen.Draw(0, 0, spinnerChar, Green, Black);
            Screen.Draw(0, Rows - 1, $"L {sbLength}", White, Black);
            RenderFps(fps);
            string output = Screen.Render();
            outs.Write(output);
            outs.Flush();
            sbLength = output.Length;
        }
        
        outs.Flush();
        Console.Clear();
        Screen.ResetAlternateScreenBuffer();
    }
}