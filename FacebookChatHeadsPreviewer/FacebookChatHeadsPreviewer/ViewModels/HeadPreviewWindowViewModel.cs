using FacebookChatHeadsPreviewer.Enums;
using FacebookChatHeadsPreviewer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FacebookChatHeadsPreviewer.ViewModels
{
    public class HeadPreviewWindowViewModel : INotifyPropertyChanged
    {
        private string _imgpath;
        public HeadPreviewWindow thiswin;
        public HeadPreviewWindowViewModel(String path, ImageSourceType type)
        {
            switch(type)
            {
                case ImageSourceType.FilePath:
                    imgpath = path;
                    break;
            }
        }

        public HeadPreviewWindowViewModel(HeadPreviewWindow win, 
            BitmapImage img)
        {
            thiswin = win;
            thiswin.Big.Source = img;
            thiswin.Bubble.Source = img;
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
