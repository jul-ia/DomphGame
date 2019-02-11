using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DomphGame_v1
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        Classes.GameController controller;
        DispatcherTimer timer;
        bool finish = false;

        public GameWindow()
        {
            InitializeComponent();

            controller = new Classes.GameController();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 5);

            controller.StartGame(canvas, continueButton);
            //timer.Start();

        }

        //restart game
        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            controller.StartGame(canvas, continueButton);
        }

        //return to main menu
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            //if level was passed
            if (finish)
                controller.SaveCurrentGame();

            this.Close();
        }

        //game rules
        private void infoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(controller.GetRules());
        }

        //next game
        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            if (controller.Continue(canvas, continueButton))
            { }
            else
            {
                MessageBox.Show("Congratulations! You have finished the game!");
            }
        }

        //checking if game is passed
        private void timer_Tick(object sender, EventArgs e)
        {
            if (controller.GameCheck())
            {
                finish = true;
            }

            if (finish)
            {
                continueButton.IsEnabled = true;
                continueButton.Visibility = Visibility.Visible;
            }
        }
    }
}
