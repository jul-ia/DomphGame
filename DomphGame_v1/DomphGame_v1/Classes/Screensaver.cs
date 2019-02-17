using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DomphGame_v1.Classes
{
    public class Screensaver
    {
        List<Bitmap> images;
        int IdCurrentGame;
        CultureInfo culture;

        Canvas canvas;

        public Screensaver(int id)
        {
            images = new List<Bitmap>();
            IdCurrentGame = id;
            AddImage();
        }

        public void AddImage()
        {
            var curCulture = culture ?? CultureInfo.CurrentUICulture;
            Bitmap im;
            int id = IdCurrentGame;
            
            foreach (DictionaryEntry item in Properties.Resources.ResourceManager.GetResourceSet(curCulture, true, true))
            {
                //System.Diagnostics.Debug.WriteLine(item.Key);
                //System.Diagnostics.Debug.WriteLine(item.Value);
                int imNumber;
                int.TryParse(item.Key.ToString().Substring(1), out imNumber);
               
                //if (item.Key.ToString() == "_" + id.ToString() && id != IdCurrentGame+100)
                //{
                //    im = (Bitmap)item.Value;
                //    images.Add(im);
                //    id++;
                //}
                if(imNumber >= IdCurrentGame && imNumber <= IdCurrentGame+100)
                {
                        im = (Bitmap)item.Value;
                         images.Add(im);
                }
            }
          
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        { 
        }

        public void GetImage(Canvas c)
        {
            c.Children.Clear();
            canvas = c;

            System.Windows.Controls.Image canvaImage = new System.Windows.Controls.Image();
            int id = 0;
            if (images.Count != 0)
            {
                canvaImage.Source = MiniGames.CreateImage.ToBitmapImage(images[id]);
                canvas.Children.Add(canvaImage);
                while (id < images.Count)
                {
                    Thread.Sleep(1000);
                    canvaImage.Source = MiniGames.CreateImage.ToBitmapImage(images[id]);
                    System.Diagnostics.Debug.WriteLine(images[id].ToString());
                    id++;
                }
            }
        }

        public int SmthTest()
        {
            return images.Count;

        }
    }
}
