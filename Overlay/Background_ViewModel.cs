using Overlay.UserControls;

namespace Overlay
{
    public class Background_ViewModel : NotifyPropertyChangedBase
    {
        private CustomColour _selectedColour;
        public CustomColour SelectedColour
        {
            get { return _selectedColour; }
            set
            {
                _selectedColour = value;
                NotifyPropertyChanged();
            }
        }

        public Background_ViewModel()
        {
        }
    }
}