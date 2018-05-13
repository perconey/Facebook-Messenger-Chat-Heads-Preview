using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FacebookChatHeadsPreviewer.ViewModels
{
    public class HeadPreviewWindowViewModel : INotifyPropertyChanged
    {
        private string _imgpath;

        public HeadPreviewWindowViewModel(String path)
        {
            imgpath = path;
        }

        public HeadPreviewWindowViewModel()
        {

        }

        public string imgpath
        {
            get { return _imgpath; }
            set
            {
                _imgpath = value;
                NotifyPropertyChanged(imgpath);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
