using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Overlay.UserControls
{
    public class CustomColour : NotifyPropertyChangedBase
    {
        private const string WHITE = "#F8F8F2";
        private const string TRANSPARENT = "#00282a36";
        private bool colourValid = true;

        private Color _colour;
        public Color Colour
        {
            get { return _colour; }
            set
            {
                _colour = value;
                NotifyPropertyChanged();
            }
        }

        private SolidColorBrush _colourBrush;
        public SolidColorBrush ColourBrush
        {
            get { return _colourBrush; }
            set
            {
                if (colourValid)
                {
                    _colourBrush = value;
                }
                else
                {
                    ColourBrush = SetColourBrushFromHex(WHITE);
                }
                NotifyPropertyChanged();
            }
        }

        private SolidColorBrush _borderColour;
        public SolidColorBrush BorderColour
        {
            get { return _borderColour; }
            set
            {
                _borderColour = value;
                NotifyPropertyChanged();
            }
        }


        private double _opacity;
        public double Opacity
        {
            get { return _opacity; }
            set
            {
                _opacity = value;
                NotifyPropertyChanged();
            }
        }


        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                SetBorderColour(value);

                NotifyPropertyChanged();
            }
        }


        public CustomColour(string hex, double opacity)
        {
            SetColourFromHex(hex);
            SetOpacity(opacity);
            IsSelected = false;
        }

        public void SetColourFromHex(string hex)
        {
            try
            {
                Colour = (Color)ColorConverter.ConvertFromString(hex);
                ColourBrush = SetColourBrushFromHex(hex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hex not valid, Setting to White", ex.Message);
                colourValid = false;
                Colour = (Color)ColorConverter.ConvertFromString(WHITE);
                ColourBrush = (SolidColorBrush)new BrushConverter().ConvertFrom(WHITE);
            }            
        }

        public void SetOpacity(double opacity)
        {
            if(opacity >= 0 || opacity <= 1)
            {
                Opacity = opacity;
            }
            else
            {
                Console.WriteLine("Opacity needs to be between 0 and 1, setting to 0.5");
                Opacity = 0.5;
            }
        }

        private SolidColorBrush SetColourBrushFromHex(string hex)
        {
            SolidColorBrush colour;

            try
            {
                colour = (SolidColorBrush)new BrushConverter().ConvertFrom(hex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hex not valid, Setting to White", ex.Message);
                colour = (SolidColorBrush)new BrushConverter().ConvertFrom(WHITE);
            }

            return colour;
        }

        private void SetBorderColour(bool isSelected)
        {
            if (isSelected)
            {
                BorderColour = SetColourBrushFromHex(WHITE);
            }
            else
            {
                BorderColour = SetColourBrushFromHex(TRANSPARENT);
            }
        }
    }
}
