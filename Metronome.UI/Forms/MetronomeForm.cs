using Metronome.Logic;
using Metronome.UI.Exceptions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Metronome.UI.Forms
{
    public partial class MetronomeForm : FormBase
    {
        private readonly IMetronome metronome;
        private readonly ISoundEmitter soundEmitter;

        private readonly string buttonStartLabelText = "Start";
        private readonly string buttonStopLabelText = "Stop";

        private readonly Color buttonStartLabelColor = Color.ForestGreen;
        private readonly Color buttonStopLabelColor = Color.Firebrick;

        public MetronomeForm()
        {
            this.metronome = Program.ServiceProvider.GetService(typeof(IMetronome)) as IMetronome ?? throw new ServiceNotConfiguredException(nameof(IMetronome));
            this.soundEmitter = Program.ServiceProvider.GetService(typeof(ISoundEmitter)) as ISoundEmitter ?? throw new ServiceNotConfiguredException(nameof(ISoundEmitter));

            this.InitializeComponent();
            this.SetDataBindings();

            this.metronome.Ticked += (s, e) => this.soundEmitter.Sound();
        }

        public int MinBeatsPerMinutes { get; } = 40;

        public int MaxBeatsPerMinutes { get; } = 300;

        public int BeatsPerMinute
        {
            get => this.metronome.BeatsPerMinute;
            set
            {
                this.metronome.BeatsPerMinute = value switch
                {
                    _ when value < this.MinBeatsPerMinutes => this.MinBeatsPerMinutes,
                    _ when value > this.MaxBeatsPerMinutes => this.MaxBeatsPerMinutes,
                    _ => value
                };

                this.OnPropertyChanged(nameof(this.BeatsPerMinute));
            }
        }

        public string CurrentControlButtonLabelText =>
            this.metronome.IsStarted ? this.buttonStopLabelText : this.buttonStartLabelText;

        public Color CurrentControlButtonLabelColor =>
            this.metronome.IsStarted ? this.buttonStopLabelColor : this.buttonStartLabelColor;

        private void ControlButtonClickedEventHandler(object sender, EventArgs e)
        {
            if (this.metronome.IsStarted)
            {
                this.metronome.Stop();
            }
            else
            {
                this.metronome.Start();
            }

            this.OnPropertyChanged(nameof(this.CurrentControlButtonLabelText), nameof(this.CurrentControlButtonLabelColor));
        }

        private void SetDataBindings()
        {
            this.beatsLabel.DataBindings.Add(nameof(this.beatsLabel.Text), this, nameof(this.BeatsPerMinute));

            this.beatsSlider.DataBindings.Add(nameof(this.beatsSlider.Value), this, nameof(this.BeatsPerMinute), true, DataSourceUpdateMode.OnPropertyChanged);
            this.beatsSlider.DataBindings.Add(nameof(this.beatsSlider.Minimum), this, nameof(this.MinBeatsPerMinutes));
            this.beatsSlider.DataBindings.Add(nameof(this.beatsSlider.Maximum), this, nameof(this.MaxBeatsPerMinutes));

            this.controlButton.DataBindings.Add(nameof(this.controlButton.Text), this, nameof(this.CurrentControlButtonLabelText));
            this.controlButton.DataBindings.Add(nameof(this.controlButton.ForeColor), this, nameof(this.CurrentControlButtonLabelColor));
        }
    }
}
