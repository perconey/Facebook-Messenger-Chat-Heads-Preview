using System;
using System.Drawing;
using System.Windows;

namespace FacebookChatHeadsPreviewer.Logic
{
    public class ImageInfoValidator
    {
        private bool _isEligible = false;
        public bool isEligible
        {
            get;
            set;
        }

        public ImageInfoValidator(Image img)
        {
            try
            {
            if (img.Height % img.Width == 0)
                isEligible = true;
            }catch(Exception ex)
            {
                MessageBox.Show("Following error has occurred: " + ex.Message);
            }
        }
    }
}
