using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DomphGame_v1.Classes
{
    class TestMiniGame : MiniGame
    {
        Button button;
        public TestMiniGame()
        {
            IsPassed = false;
            button.Click += button_Click;
        }
        public override void FillCanvas(Canvas canvas)
        {
            button = new Button();
            button.Width = 50;
            button.Height = 50;

            canvas.Children.Add(button);
            Canvas.SetLeft(button, 100);
            Canvas.SetRight(button, 100);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = false;
            MessageBox.Show("You Win!");
        }

        public override void Restart()
        {
            button.IsEnabled = true;
        }

    }
}
