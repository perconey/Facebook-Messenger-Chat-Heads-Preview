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
        public string check { get; set; }
        public ICommand SelectFileClick { get; set; }
        public ICommand DebugButtonClick { get; set; }

        public MainWindowViewModel()
        {
            SelectFileClick = new RelayCommand(onSelectFileClick, o => true);
            DebugButtonClick = new RelayCommand(onDebugButtonClick, o => true);
        }

        public void onDebugButtonClick(object o)
        {
            MessageBox.Show(check);
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
                string filename = dlg.FileName;
                //Debug
                check = dlg.FileName;
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
