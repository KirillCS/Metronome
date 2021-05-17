using System;

namespace Metronome.Logic
{
    public interface IMetronome
    {
        event EventHandler Ticked;

        int BeatsPerMinute { get; set; }

        bool IsStarted { get; }

        void Start();

        void Stop();
    }
}
