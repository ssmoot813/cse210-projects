using System;
using System.Threading;
public class BreathingActivity : Activity
{
    private int _inhaleSeconds;
    private int _exhaleSeconds;
    private int _barWidth;

    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _inhaleSeconds = 4;
        _exhaleSeconds = 6;
        _barWidth = 30;
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            ShowBreath("Breathe in...      ", _inhaleSeconds, true);
            ShowBreath("Now breathe out... ", _exhaleSeconds, false);
        }

        DisplayEndingMessage();
    }

    private void ShowBreath(string message, int seconds, bool breathingIn)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        double totalMilliseconds = seconds * 1000.0;

        while (DateTime.Now < endTime)
        {
            double elapsed = (DateTime.Now - startTime).TotalMilliseconds;
            double progress = Math.Min(elapsed / totalMilliseconds, 1.0);

            double eased = 1 - (1 - progress) * (1 - progress);
            double fill = breathingIn ? eased : 1 - eased;
            int width = (int)Math.Round(fill * _barWidth);

            int secondsLeft = (int)Math.Ceiling((totalMilliseconds - elapsed) / 1000.0);
            string bar = new string('~', width).PadRight(_barWidth);

            Console.Write($"\r{message}[{bar}] {secondsLeft} ");
            Thread.Sleep(50);
        }

        string finalBar = new string(breathingIn ? '~' : ' ', _barWidth);
        Console.WriteLine($"\r{message}[{finalBar}]   ");
    }
}