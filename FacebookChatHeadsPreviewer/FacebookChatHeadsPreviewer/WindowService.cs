using System.Windows;

namespace FacebookChatHeadsPreviewer
{
    class WindowService
    //IWindowService cc
    {
        public void ShowWindow(object viewModel)
        {
            var win = new Window
            {
                Content = viewModel
            };
            win.Show();
        }
    }
}
