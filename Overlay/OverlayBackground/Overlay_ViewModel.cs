using Overlay.UserControls;

namespace Overlay.OverlayBackground
{
    public class Overlay_ViewModel : NotifyPropertyChangedBase
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

        public Overlay_ViewModel()
        {
        }
    }
}