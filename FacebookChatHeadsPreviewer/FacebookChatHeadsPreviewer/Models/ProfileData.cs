using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookChatHeadsPreviewer.Models
{
    public class ProfileData
    {
        public string Name { get; set; }

        public ProfileData(string name)
        {
            Name = name;
        }

        public ProfileData()
        {
        }
    }
}
