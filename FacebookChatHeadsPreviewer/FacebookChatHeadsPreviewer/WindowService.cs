using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
