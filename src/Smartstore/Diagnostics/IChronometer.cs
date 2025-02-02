﻿using Smartstore.Utilities;

namespace Smartstore.Diagnostics
{
    public interface IChronometer : IDisposable
    {
        void StepStart(string key, string message);
        void StepStop(string key);
    }

    public static class IChronometerExtensions
    {
        public static IDisposable Step(this IChronometer chronometer, string message)
        {
            Guard.NotEmpty(message, nameof(message));

            var key = "step" + CommonHelper.GenerateRandomDigitCode(10);

            chronometer.StepStart(key, message);
            return new ActionDisposable(() => chronometer.StepStop(key));
        }
    }

    public class NullChronometer : IChronometer
    {
        public static IChronometer Instance => new NullChronometer();

        public void StepStart(string key, string message)
        {
        }

        public void StepStop(string key)
        {
        }

        public void Dispose()
        {
        }
    }
}
