﻿using Metronome.Logic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Metronome.UI
{
    public partial class MetronomeForm : Form, INotifyPropertyChanged
    {
        private readonly string buttonStartLabelText = "Start";
        private readonly string buttonStopLabelText = "Stop";

        private readonly Color buttonStartLabelColor = Color.ForestGreen;
        private readonly Color buttonStopLabelColor = Color.Firebrick;

        private readonly IMetronome metronome = new Logic.Metronome(60);
        private readonly ISoundEmitter soundEmitter = new SoundEmitter(1000, 50);

        public event PropertyChangedEventHandler PropertyChanged;

        public MetronomeForm()
        {
            this.InitializeComponent();
            this.SetDataBindings();

            this.MinBeatsPerMinutes = 40;
            this.MaxBeatsPerMinutes = 300;

            this.metronome.Ticked += (s, e) => this.soundEmitter.Sound();
        }

        public int MinBeatsPerMinutes { get; }

        public int MaxBeatsPerMinutes { get; }

        public int BeatsPerMinute
        {
            get => this.metronome.BeatsPerMinute;
            set
            {
                if (value < this.MinBeatsPerMinutes)
                {
                    value = this.MinBeatsPerMinutes;
                }

                if (value > this.MaxBeatsPerMinutes)
                {
                    value = this.MaxBeatsPerMinutes;
                }

                this.metronome.BeatsPerMinute = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.BeatsPerMinute)));
            }
        }

        public string CurrentControlButtonLabelText =>
            this.metronome.IsStarted ? this.buttonStopLabelText : this.buttonStartLabelText;

        public Color CurrentControlButtonLabelColor =>
            this.metronome.IsStarted ? this.buttonStopLabelColor : this.buttonStartLabelColor;

        private void OnControlButtonClicked(object sender, EventArgs e)
        {
            if (this.metronome.IsStarted)
            {
                this.metronome.Stop();
            }
            else
            {
                this.metronome.Start();
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentControlButtonLabelText)));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentControlButtonLabelColor)));
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
