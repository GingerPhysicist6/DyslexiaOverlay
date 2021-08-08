using Overlay.UserControls;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Overlay
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        private const string RED = "#FF0000";
        private const string GREEN = "#00FF00";
        private const string BLUE = "#0000FF";
        private const string WHITE = "#F8F8F2";
        private const string TRANSPARENT = "#00282a36";
        private const double START_OPACITY = 0.5;
        private const int START_INDEX = 2; // Green
        private int SelectedIndex;

        public Background_ViewModel BackgroundViewModel { get; set; }

        public ObservableCollection<CustomColour> FavouriteColours { get; set; }
        public CustomColour FavouriteColour0_Placeholder { get; private set; }
        public CustomColour FavouriteColour1 { get; private set; }
        public CustomColour FavouriteColour2 { get; private set; }
        public CustomColour FavouriteColour3 { get; private set; }

        public RelayCommand Exit { get; set; }
        public RelayCommand ChangeColour1 { get; set; }
        public RelayCommand ChangeColour2 { get; set; }
        public RelayCommand ChangeColour3 { get; set; }


        private ImageSource _colourWheel;
        public ImageSource ColourWheel
        {
            get { return _colourWheel; }
            set
            {
                _colourWheel = value;
                NotifyPropertyChanged();
            }
        }

        private ImageSource _exit;
        public ImageSource ExitIcon
        {
            get { return _exit; }
            set
            {
                _exit = value;
                NotifyPropertyChanged();
            }
        }

        private SolidColorBrush _miscColourSelected;
        public SolidColorBrush MiscColourSelected
        {
            get { return _miscColourSelected; }
            set
            {
                _miscColourSelected = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel(Background background)
        {
            BackgroundViewModel = new Background_ViewModel();
            background.DataContext = BackgroundViewModel;
            GenerateStartFavouriteColour();
            InitIcons();
            InitCommands();
        }

        private void GenerateStartFavouriteColour()
        {
            FavouriteColour0_Placeholder = new CustomColour(WHITE, START_OPACITY);
            FavouriteColour1 = new CustomColour(RED, START_OPACITY);
            FavouriteColour2 = new CustomColour(GREEN, START_OPACITY);
            FavouriteColour3 = new CustomColour(BLUE, START_OPACITY);

            FavouriteColours = new ObservableCollection<CustomColour>();

            FavouriteColours.Add(FavouriteColour0_Placeholder);
            FavouriteColours.Add(FavouriteColour1);
            FavouriteColours.Add(FavouriteColour2);
            FavouriteColours.Add(FavouriteColour3);
            SetSelectedIndex(START_INDEX);
        }

        private void InitIcons()
        {
            ColourWheel = new BitmapImage(new Uri("/Overlay;component/ColourWheel.png", UriKind.Relative));
            ExitIcon = new BitmapImage(new Uri("/Overlay;component/Exit.png", UriKind.Relative));
        }

        private void InitCommands()
        {
            Exit = new RelayCommand(Execute_ExitCommand, CanExecute_Commands);
            ChangeColour1 = new RelayCommand(Execute_ChangeToFavourite1Command, CanExecute_Commands);
            ChangeColour2 = new RelayCommand(Execute_ChangeToFavourite2Command, CanExecute_Commands);
            ChangeColour3 = new RelayCommand(Execute_ChangeToFavourite3Command, CanExecute_Commands);
        }

        //private void SetSelectedIndex(int index)
        //{
        //    SelectedIndex = index;

        //    if (index != 0)
        //    {
        //        MiscColourSelected = (SolidColorBrush)new BrushConverter().ConvertFrom(TRANSPARENT);
        //        SelectedColour = FavouriteColours[index];

        //        foreach (CustomColour colours in FavouriteColours)
        //        {
        //            FavouriteColours[index].IsSelected = false;
        //        }

        //        FavouriteColours[index].IsSelected = true;
        //    }
        //    else
        //    {
        //        MiscColourSelected = (SolidColorBrush)new BrushConverter().ConvertFrom(WHITE);
        //    }
        //}

        private void SetSelectedIndex(int index)
        {
            SelectedIndex = index;

            if (index != 0)
            {
                MiscColourSelected = (SolidColorBrush)new BrushConverter().ConvertFrom(TRANSPARENT);
                BackgroundViewModel.SelectedColour = FavouriteColours[index];

                FavouriteColour1.IsSelected = false;
                FavouriteColour2.IsSelected = false;
                FavouriteColour3.IsSelected = false;

                if (index == 1)
                {
                    FavouriteColour1.IsSelected = true;
                }
                else if (index == 2)
                {
                    FavouriteColour2.IsSelected = true;
                }
                else if (index == 3)
                {
                    FavouriteColour3.IsSelected = true;
                }
            }
            else
            {
                MiscColourSelected = (SolidColorBrush)new BrushConverter().ConvertFrom(WHITE);
            }
        }

        public void Execute_ExitCommand(object param)
        {
            Environment.Exit(0);
        }

        public void Execute_ChangeToFavourite1Command(object param)
        {
            SetSelectedIndex(1);
        }

        public void Execute_ChangeToFavourite2Command(object param)
        {
            SetSelectedIndex(2);
        }

        public void Execute_ChangeToFavourite3Command(object param)
        {
            SetSelectedIndex(3);
        }

        public bool CanExecute_Commands(object param)
        {
            return true;
        }
    }
}