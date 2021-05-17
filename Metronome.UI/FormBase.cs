using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Metronome.UI
{
    public class FormBase : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName is null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(params string[] propertiesNames)
        {
            if (propertiesNames is null)
            {
                throw new ArgumentNullException(nameof(propertiesNames));
            }

            foreach (string name in propertiesNames)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
