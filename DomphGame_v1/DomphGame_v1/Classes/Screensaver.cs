using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DomphGame_v1.Classes
{
    public class Screensaver
    {
        List<BitmapImage> images;
        int IdCurrentGame;
        public Screensaver(int id)
        {
            images = new List<BitmapImage>();
            IdCurrentGame = id;
        }

        private void AddImage()
        {
            images.Add(new BitmapImage(new Uri(@"..\..\Resourser\101.png")));
        }

        public BitmapImage GetImage(int index)
        {
            foreach (var item in images)
            {
                if (item.ToString() == index.ToString())
                    return item;
            }
            return null;
        }

        public void SmthTest()
        {
           // if()
        }
    }
}
