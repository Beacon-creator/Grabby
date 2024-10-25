using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace Grabby_Two.Model
{
    public class ShowPasswordClass : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        public string? ShowIcon { get; set; }
        public string? HideIcon { get; set; }

        private bool _hidePassword = true;

        public bool HidePassword
        {
            set
            {
                if (_hidePassword != value)
                {
                    _hidePassword = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HidePassword)));
                }
            }
            get => _hidePassword;
        }

        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HidePassword ? ShowIcon : HideIcon;
            HidePassword = !HidePassword;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
