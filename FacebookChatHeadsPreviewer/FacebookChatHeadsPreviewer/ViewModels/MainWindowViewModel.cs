using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FacebookChatHeadsPreviewer.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand SelectFileClick { get; set; }

        public MainWindowViewModel()
        {
            SelectFileClick = new RelayCommand(onSelectFileClick, o => true);
        }

        public void onSelectFileClick(object o)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".png",
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg"
            };
            bool? result = dlg.ShowDialog();

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
