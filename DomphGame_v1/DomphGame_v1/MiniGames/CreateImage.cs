using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Interop;
using System.Drawing.Imaging;

namespace DomphGame_v1.MiniGames
{
    /// <summary>
    /// create image from cropped pieces using rotation
    /// </summary>
    class CreateImage : MiniGame
    {
        Canvas GameCanvas;          //game canvas
        BitmapImage image;          //image 
        RectangleImage[,] field;    //rectangle field of image pieces
        int w, h;                   //width and height

        Button continueButton;      

        public CreateImage(Bitmap im, int x, int y)
        {
            w = x;
            h = y;
            //image = BitmapToBitmapImage(im);
            image = ToBitmapImage(im);
        }

        public static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new System.IO.MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        //filling canvas with cropped images
        public override void FillCanvas()
        {
            //c.Children.Clear();
            //GameCanvas = c;
            //GameCanvas.MouseDown += canvas_MouseDown;           

            int cw, ch, cwCanvas, chCanvas;
            cw = (int)(image.PixelWidth / w);
            ch = (int)(image.PixelHeight / h);

            cwCanvas = (int)(image.Width / w) + 1;
            chCanvas = (int)(image.Height / h) + 1;

            field = new RectangleImage[w, h];
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    field[i, j] = new RectangleImage(new CroppedBitmap(image, new System.Windows.Int32Rect(j * cw, i * ch, cw, ch)));
                    GameCanvas.Children.Add(field[i, j].Rect);

                    field[i, j].Rotate(new Random((int)DateTime.Now.Ticks).Next(0, 4) * 90);

                    Canvas.SetLeft(field[i, j].Rect, j * cwCanvas);
                    Canvas.SetTop(field[i, j].Rect, i * chCanvas);
                }
            }
        }

        //check if image is complete
        public bool ImageCheck()
        {
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                    if (field[i, j].Angle != 0)
                        return false;
            }
            return true;
        }

        public bool StopRotate()
        {
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                    field[i, j].DisableRect();
            }
            return true;
        }

        public override void Restart(Canvas c, Button button)
        {
            c.Children.Clear();
            GameCanvas = c;
            GameCanvas.MouseDown += canvas_MouseDown;

            IsPassed = false;

            continueButton = button;
            continueButton.IsEnabled = false;
            continueButton.Visibility = Visibility.Hidden;

            //GameCanvas.Children.Add(continueButton);
            //Canvas.SetLeft(continueButton, (GameCanvas.Width / 2) - (continueButton.Width / 2));
            //Canvas.SetTop(continueButton, (GameCanvas.Height / 2) - (continueButton.Height / 2));

            FillCanvas();
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ImageCheck())
            {
                StopRotate();
                IsPassed = true;

                continueButton.IsEnabled = true;
                continueButton.Visibility = Visibility.Visible;

                GameCanvas.Children.Add(continueButton);
                Canvas.SetLeft(continueButton, (GameCanvas.Width / 2) - (continueButton.Width / 2));
                Canvas.SetTop(continueButton, (GameCanvas.Height / 2) - (continueButton.Height / 2));
            }
        }

        public override string GetRules()
        {
            return "Складіть картинку, повертаючи елементи на 90 градусів!";
        }

    }

    class RectangleImage
    {
        public System.Windows.Shapes.Rectangle Rect { get; set; }
        public CroppedBitmap Image { get; set; }
        public int Angle { get; set; }

        public RectangleImage(CroppedBitmap im)
        {
            Angle = 0;
            Image = im;
            Rect = new System.Windows.Shapes.Rectangle();
            Rect.MouseDown += Rect_MouseDown;
            Rect.Height = im.Height;
            Rect.Width = im.Width;
            Rect.Fill = new ImageBrush(im);

        }

        public void Rotate(int angle)
        {
            Angle = angle;
            RotateTransform rotate = new RotateTransform(angle, Rect.Width / 2, Rect.Height / 2);
            Rect.RenderTransform = rotate;
        }

        //rectangle rotate
        private void Rect_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle current = (sender as System.Windows.Shapes.Rectangle);
            Angle += 90;
            RotateTransform rotate = new RotateTransform(Angle, current.Width / 2, current.Height / 2);
            current.RenderTransform = rotate;

            if (Angle == 360)
                Angle = 0;

            // System.Diagnostics.Debug.WriteLine("angle = {0}", Angle);
        }

        public void DisableRect()
        {
            if (Angle == 0)
                Rect.IsEnabled = false;
        }

    }
}
