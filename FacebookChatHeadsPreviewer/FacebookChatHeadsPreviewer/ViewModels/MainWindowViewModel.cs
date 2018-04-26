using FacebookChatHeadsPreviewer.Logic;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using FacebookChatHeadsPreviewer.Views;
using System;
using System.Windows.Controls;

namespace FacebookChatHeadsPreviewer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //debug
        public string check { get; set; }

        private string _windowState;
        private WebBrowser web = new WebBrowser();

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
        

        public MainWindowViewModel()
        {
            _windowState = "Visible";
            SelectFileClick = new RelayCommand(onSelectFileClick, o => true);
            DebugButtonClick = new RelayCommand(onDebugButtonClick, o => true);
            SearchButtonClick = new RelayCommand(onSearchButtonClick, o => true);

            web.Navigate("https://findmyfbid.com/");
        }

        public void onDebugButtonClick(object o)
        {
            MessageBox.Show(check);
        }

        public void onSearchButtonClick(object o)
        {
            var elem = web.Document
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

                    win.DataContext = new HeadPreviewWindowViewModel(path);
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
