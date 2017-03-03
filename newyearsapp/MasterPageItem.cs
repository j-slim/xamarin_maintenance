using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace newyearsapp
{
    class MasterPageItem
    {
        public MasterPageItem(string name, DateTime birthday, Color favoriteColor, String iconSource, Type targetType)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.FavoriteColor = favoriteColor;
            this.IconSource = iconSource;
            this.TargetType = targetType;
        }

        public string Name { private set; get; }

        public DateTime Birthday { private set; get; }

        public Color FavoriteColor { private set; get; }

        public String IconSource { private set; get; }

        public Type TargetType { private set; get; }

    }
}
