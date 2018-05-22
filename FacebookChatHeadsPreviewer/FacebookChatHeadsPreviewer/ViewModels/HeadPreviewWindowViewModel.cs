using FacebookChatHeadsPreviewer.Enums;
using FacebookChatHeadsPreviewer.Models;
using FacebookChatHeadsPreviewer.Views;
using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace FacebookChatHeadsPreviewer.ViewModels
{
    public class HeadPreviewWindowViewModel : INotifyPropertyChanged
    {
        private string _imgpath;
        public HeadPreviewWindow thiswin;
        public HeadPreviewWindowViewModel(String path, 
            ImageSourceType type, ProfileData data)
        {
            switch(type)
            {
                case ImageSourceType.FilePath:
                    imgpath = path;
                    break;
            }
        }

        public HeadPreviewWindowViewModel(HeadPreviewWindow win, 
            BitmapImage img, ProfileData data)
        {
            thiswin = win;
            thiswin.ChatFloat.Source = img;
            thiswin.ChatList.Source = img;
            thiswin.Big.Source = img;
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
            PropertyChanged?.Invoke
                (this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
