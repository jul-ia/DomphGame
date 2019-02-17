using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DomphGame_v1.MiniGames
{
    class TestMiniGame : MiniGame
    {
        Canvas canvas;

        Button button1, button2, button3;

        Button continueButton;

        public TestMiniGame()
        {
            IsPassed = false;
        }
        public override void FillCanvas()
        {

            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button1.Width = button2.Width = button3.Width = 50;
            button1.Height = button2.Height = button3.Height = 50;
            button1.Content = "1";
            button2.Content = "2";
            button3.Content = "3";

            canvas.Children.Add(button1);
            canvas.Children.Add(button2);
            canvas.Children.Add(button3);

            Canvas.SetLeft(button1, 100);
            Canvas.SetTop(button1, 50);

            Canvas.SetLeft(button2, 50);
            Canvas.SetTop(button2, 150);

            Canvas.SetLeft(button3, 150);
            Canvas.SetTop(button3, 150);

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;

            button2.IsEnabled = false;
            button3.IsEnabled = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
            button2.IsEnabled = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button2.IsEnabled = false;
            button3.IsEnabled = true;
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            button3.IsEnabled = false;
            IsPassed = true;
            MessageBox.Show("You Win!");

            continueButton.IsEnabled = true;
            continueButton.Visibility = Visibility.Visible;
            
        }

        public override void Restart(Canvas c, Button con)
        {
            c.Children.Clear();
            canvas = c;

            IsPassed = false;
            continueButton = con;
            continueButton.IsEnabled = false;
            continueButton.Visibility = Visibility.Hidden;
            canvas.Children.Add(continueButton);
            Canvas.SetLeft(continueButton, (canvas.Width / 2) - (continueButton.Width / 2));
            Canvas.SetTop(continueButton, (canvas.Height / 2) - (continueButton.Height / 2));

            FillCanvas();

            button1.IsEnabled = true;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
        }

    }
}
