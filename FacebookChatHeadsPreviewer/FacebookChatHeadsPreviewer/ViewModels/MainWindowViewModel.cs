using FacebookChatHeadsPreviewer.Logic;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using FacebookChatHeadsPreviewer.Views;
using System;
using FacebookChatHeadsPreviewer.Enums;

namespace FacebookChatHeadsPreviewer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //debug
        public string check { get; set; }
        //

        private FacebookProfilePhotoLoader _loader = new FacebookProfilePhotoLoader();       

        private string _searchBoxText;
        private string _windowState;

        public Action CloseAction { get; set; }

        public ICommand SelectFileClick { get; set; }
        public ICommand DebugButtonClick { get; set; }
        public ICommand SearchButtonClick { get; set; }

        public string WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                _windowState = value;
                NotifyPropertyChanged("WindowState");
            }
        }

        public string SearchBoxText
        {
            get => _searchBoxText;
            set
            {
                NotifyPropertyChanged("SearchBoxText");
                _searchBoxText = value;
            }

        }

        internal FacebookProfilePhotoLoader Loader
        {
            get => _loader;
            set => _loader = value;
        }

        public MainWindowViewModel()
        {
            _windowState = "Visible";
            SelectFileClick = new RelayCommand(onSelectFileClick, o => true);
            DebugButtonClick = new RelayCommand(onDebugButtonClick, o => true);
            SearchButtonClick = new RelayCommand(onSearchButtonClick, o => true);
            var fbrecieve = new FacebookProfilePhotoLoader();
        }

        public void onDebugButtonClick(object o)
        {
            MessageBox.Show(check);
        }

        public void onSearchButtonClick(object o)
        {
            Loader.SearchByUrl(SearchBoxText);
            if (Loader.IdGood())
            {
                WindowState = "Hidden";
                var win = new HeadPreviewWindow();
                win.DataContext = new HeadPreviewWindowViewModel(win);
                win.Show();
                CloseAction();
            }
        }


        public void onSelectFileClick(object o)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".png",
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg"
            };
            bool? dialogOK = dlg.ShowDialog();
            if(dialogOK == true)
            {
                string path = dlg.FileName;
                Image img = Image.FromFile(path);
                var validator = new ImageInfoValidator(img);

                //image is square
                if(validator.isEligible)
                {
                    WindowState = "Hidden";
                    var win = new HeadPreviewWindow();

                    win.DataContext = new HeadPreviewWindowViewModel(path, ImageSourceType.FilePath);
                    win.Show();
                    CloseAction();
                }
                //image is not square
                else
                {
                    MessageBox.Show("Your image height/width ratio is not correct. You only can use square photos on Facebook. Please reselect your photo");
                }
            }
            else
            {
                //action on no select
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
