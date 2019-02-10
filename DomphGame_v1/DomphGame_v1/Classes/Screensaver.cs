using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
        CultureInfo culture;

        public Screensaver(int id)
        {
            images = new List<BitmapImage>();
            IdCurrentGame = id;
            AddImage();
        }
        
        public void AddImage()
        {
            var curCulture = culture ?? CultureInfo.CurrentUICulture;
            BitmapImage im = new BitmapImage();
            foreach (DictionaryEntry item in Properties.Resources.ResourceManager.GetResourceSet(curCulture, true, true))
            {
                //System.Diagnostics.Debug.WriteLine(item.Key);
                //System.Diagnostics.Debug.WriteLine(item.Value);
                im = (BitmapImage)item.Value;

                images.Add(im);
            }
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
