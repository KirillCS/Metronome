using System;
using System.Threading;
using System.Threading.Tasks;

namespace Metronome.Logic
{
    public sealed class Metronome : IMetronome
    {
        private const int SecondsToMinutes = 60;
        private const int MillisecondsToSeconds = 1000;

        private int beatsPerMinute;
        private int millisecondsTimeout;

        public event EventHandler Ticked;

        public Metronome()
            : this(100)
        {
        }

        public Metronome(int beatsPerMinute)
        {
            this.BeatsPerMinute = beatsPerMinute;
        }

        public int BeatsPerMinute
        {
            get => this.beatsPerMinute;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Beats per minute cannot equals or be less than zero");
                }

                this.beatsPerMinute = value;
                this.millisecondsTimeout = (int)(1D / value * SecondsToMinutes * MillisecondsToSeconds);
            }
        }

        public bool IsStarted { get; private set; }

        public async void Start()
        {
            this.IsStarted = true;
            await Task.Run(() =>
            {
                while (this.IsStarted)
                {
                    Thread.Sleep(this.millisecondsTimeout);
                    this.Ticked?.Invoke(this, EventArgs.Empty);
                }
            });
        }

        public void Stop()
        {
            this.IsStarted = false;
        }
    }
}
