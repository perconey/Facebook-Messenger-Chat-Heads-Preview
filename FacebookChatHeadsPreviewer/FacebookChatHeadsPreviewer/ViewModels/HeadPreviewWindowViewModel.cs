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
        private string _name;

        public HeadPreviewWindow thiswin;
        public ProfileData profile = null;

        public HeadPreviewWindowViewModel(String path, 
            ImageSourceType type, ProfileData data)
        {
            profile = data;
            switch (type)
            {
                case ImageSourceType.FilePath:
                    imgpath = path;
                    Name = profile.Name;
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
            profile = data;
           // BindTextFields();
        }

        public HeadPreviewWindowViewModel()
        {

        }

        public void BindTextFields()
        {
            thiswin.NameList.Content = profile.Name;
            thiswin.NameTop.Content = profile.Name;
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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged(Name);
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
