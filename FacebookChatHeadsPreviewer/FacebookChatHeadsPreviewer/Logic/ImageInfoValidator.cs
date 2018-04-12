using System;
using System.Drawing;
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
            if (img.Height % img.Width == 0)
                isEligible = true;
        }
    }
}
