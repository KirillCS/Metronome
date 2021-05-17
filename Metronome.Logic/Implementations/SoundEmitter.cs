using System;

namespace Metronome.Logic
{
    public class SoundEmitter : ISoundEmitter
    {
        private readonly int frequency;
        private readonly int duration;

        public SoundEmitter(int frequency, int duration)
        {
            if (frequency < 37 || frequency > 32767)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency), $"{nameof(frequency)} cannot be less than 37 hertz or more than 32767 hertz");
            }

            if (duration < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(duration), $"{nameof(duration)} cannot be negative");
            }

            this.frequency = frequency;
            this.duration = duration;
        }

        public void Sound()
        {
            Console.Beep(this.frequency, this.duration);
        }
    }
}
