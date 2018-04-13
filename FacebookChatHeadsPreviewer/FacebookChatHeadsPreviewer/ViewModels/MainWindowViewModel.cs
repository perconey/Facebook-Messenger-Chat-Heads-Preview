using FacebookChatHeadsPreviewer.Logic;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Input;

namespace FacebookChatHeadsPreviewer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
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
                string path = dlg.FileName;
                Image img = Image.FromFile(path);
                var validator = new ImageInfoValidator(img);

                //image is square
                if(validator.isEligible)
                {

                }
                //image is not square
                else
                {
                    MessageBox.Show("Your image height/width ratio is not correct. You only can use square photos on Facebook");
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
